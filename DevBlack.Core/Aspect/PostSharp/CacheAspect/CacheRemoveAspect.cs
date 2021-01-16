using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.CrossCutingConcerns.Cache;
using PostSharp.Aspects;

namespace DevBlack.Core.Aspect.PostSharp.CacheAspect
{
    [Serializable]
   public class CacheRemoveAspect:OnMethodBoundaryAspect
   {
       private string _pattern;

       public CacheRemoveAspect(string pattern,Type cacheType)
       {
           _pattern = pattern;
           _cacheType = cacheType;
       }

       private Type _cacheType;
       private ICacheManager _manager;
       public CacheRemoveAspect(Type cacheType)
       {
           _cacheType = cacheType;
       }
       public override void RuntimeInitialize(MethodBase method)
       {
           if (typeof(ICacheManager).IsAssignableFrom(_cacheType))
           {
               return;
           }

           _manager = (ICacheManager) Activator.CreateInstance(_cacheType);
           
           base.RuntimeInitialize(method);
       }

       // method başarılı olursa ürün güncellendiğinde yada silindiğinde bizim cache i silmemimiz lazım
       public override void OnSuccess(MethodExecutionArgs args)
       {
           _manager.RemoveByPattern(string.IsNullOrEmpty(_pattern)? $"{args.Method.ReflectedType.Namespace},{args.Method.ReflectedType.Name}"
               :_pattern);
       }
   }
}
