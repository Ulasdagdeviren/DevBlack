using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.CrossCutingConcerns.Cache;
using PostSharp.Aspects;

namespace DevBlack.Core.Aspect.PostSharp.CacheAspect
{[Serializable]
   public class CacheAspect:MethodInterceptionAspect
   {
       private Type _cacheType;
       private int _cacheminute;
       private ICacheManager _manager;

       public CacheAspect(Type cacheType, int cacheminute)
       {
           _cacheType = cacheType;
           _cacheminute = cacheminute;
       }

       public override void RuntimeInitialize(MethodBase method)// instance create
       {
           if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false) // IsAssignableFrom= atanabilir demektir
           {
               throw new Exception("Wrong Cache Manager");
           }

           _manager = (ICacheManager) Activator.CreateInstance(_cacheType);

           base.RuntimeInitialize(method);
       }

       public override void OnInvoke(MethodInterceptionArgs args) // Method çalıştırlmadan önce
       {
           var method = string.Format("{0},{1},{2}", args.Method.ReflectedType.Namespace,
               args.Method.ReflectedType.Name,
               args.Method.Name);
           var arguments = args.Arguments.ToList();
           var key=string.Format("{0}({1})",method,
               string.Join(",",arguments.Select(x=>x!=null ? x.ToString():"<Null>")));
           if (_manager.Contain(key))
           {
               args.ReturnValue = _manager.Get<object>(key);
           }
           base.OnInvoke(args);
           _manager.Add(key,args.ReturnValue,_cacheminute);
       }
   }
}
