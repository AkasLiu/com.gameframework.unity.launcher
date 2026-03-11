/// <summary>
/// 2025-12-10 Game Framework Code By Hurley
/// </summary>

using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;


public class OriginalClass
{
    public int Uid { get; set; }
    public string Name { get; set; }
}

namespace Game
{
    /// <summary>
    /// Logo场景
    /// </summary>
    static class LogoSceneSystem
    {
        [OnAwake]
        static void Awake(this LogoScene self)
        {
        }

        [OnStart]
        static void Start(this LogoScene self)
        {
            self.AddComponent<TestChildComponent>();
        }

        [OnDestroy]
        static void Destroy(this LogoScene self)
        {
            self.RemoveComponent<ContextPreBuiltComponent>();
        }

        [OnBeanInput((int) UnityEngine.KeyCode.A, GameEngine.InputOperationType.Released)]
        static void OnStartGameClicked(this LogoScene self)
        {
            ContextDataComponent component = self.GetComponent<ContextDataComponent>();
            if (component.isCompleted)
            {
                GameEngine.GameApi.ReplaceScene("Loading");
            }
            else
            {
                GameEngine.GameApi.Send(new ContextDataComponent.ContextDataBuiltNotify() { regain = false });

                if (!self.HasComponent<ContextPreBuiltComponent>())
                {
                    // 添加业务组件
                    self.AddComponent<ContextPreBuiltComponent>();
                }
            }
        }

        [OnBeanInput((int) UnityEngine.KeyCode.R, GameEngine.InputOperationType.Released)]
        static void OnResetGameClicked(this LogoScene self)
        {
            ContextDataComponent component = self.GetComponent<ContextDataComponent>();
            if (component.isCompleted)
            {
                Debugger.Info("开始重构当前的游戏上下文数据，请等待重构完成后再进行其它操作！");
                GameEngine.GameApi.Send(new ContextDataComponent.ContextDataBuiltNotify() { regain = true });
            }
            else
            {
                Debugger.Info("游戏上下文数据当前尚未构建（还未开始构建或正处于构建过程中），无法立即进行重构操作！");
            }
        }

        [OnBeanInput((int) UnityEngine.KeyCode.X, GameEngine.InputOperationType.Released)]
        static void OnTestGameClicked(this LogoScene self)
        {
            //dynamic myObj = new OriginalClass();
            //myObj.TargetMethod = new Action<string>((s) => Debugger.Warn("Modified logic: {%s}", s));
            //myObj.TargetMethod("Test");

            //if (null != myObj) return;

            //// 获取目标类型和方法
            //Type originalType = typeof(OriginalClass);
            //MethodInfo originalMethod = originalType.GetMethod("TargetMethod");

            //// 获取原始方法参数类型
            //var paramTypes = originalMethod.GetParameters()
            //                               .Select(p => p.ParameterType)
            //                               .ToArray();

            //// 创建动态方法
            //DynamicMethod dynamicMethod = new DynamicMethod(
            //    "ModifiedMethod",
            //    originalMethod.ReturnType,
            //    // originalMethod.GetParameters().Select(p => p.ParameterType).ToArray(),
            //    paramTypes,
            //    originalType,
            //    true
            //);

            //// 获取IL生成器
            //ILGenerator il = dynamicMethod.GetILGenerator();

            //// 添加自定义逻辑
            //il.Emit(OpCodes.Ldstr, "Before original logic");
            //il.Emit(OpCodes.Call, typeof(Debugger).GetMethod("Warn", new Type[] { typeof(string) }));

            //// 调用原始方法
            //il.Emit(OpCodes.Ldarg_0); // 加载this参数
            //// for (int i = 0; i < originalMethod.GetParameters().Length; i++)
            //for (int i = 0; i < paramTypes.Length; i++)
            //{
            //    Debugger.Warn("param type {%t}", paramTypes[i]);
            //    il.Emit(OpCodes.Ldarg, i + 1); // 加载参数
            //}
            //il.Emit(OpCodes.Call, originalMethod);

            //// 添加更多自定义逻辑
            //il.Emit(OpCodes.Ldstr, "After original logic");
            //il.Emit(OpCodes.Call, typeof(Debugger).GetMethod("Warn", new Type[] { typeof(string) }));

            //// 返回结果
            //il.Emit(OpCodes.Ret);

            //// 替换原始方法
            //originalMethod = dynamicMethod;

            // 测试
            OriginalClass obj = new OriginalClass();
            // obj.TargetMethod("Test");
            // originalMethod.Invoke(obj, new object[] { "Test" });
            obj.Name = "hello";

            Debugger.Warn("11111111111111111111");
            var proxy = CreateProxy<OriginalClass>(obj);
            Debugger.Warn("{%t} - {%t}", proxy, proxy.GetType().BaseType);
            proxy.Name = "xx";
            string s = proxy.Name;
            Debugger.Warn(s);
        }

        static T CreateProxy<T>(T target) where T : class
        {
            var type = typeof(T);
            var assemblyName = new AssemblyName("DynamicProxyAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            var typeBuilder = moduleBuilder.DefineType("DynamicProxyType", TypeAttributes.Public | TypeAttributes.Class, type);

            Debugger.Warn("{%t} property count {%d}", type, type.GetProperties().Length);
            foreach (var property in type.GetProperties())
            {
                Debugger.Warn("property name {%s}", property.Name);
                var propertyBuilder = typeBuilder.DefineProperty(property.Name, property.Attributes, property.PropertyType, null);

                var getMethod = property.GetGetMethod();
                if (getMethod != null)
                {
                    var getMethodBuilder = typeBuilder.DefineMethod(
                        "get_" + property.Name,
                        //MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                        getMethod.Attributes,
                        property.PropertyType,
                        Type.EmptyTypes);

                    var ilGenerator = getMethodBuilder.GetILGenerator();
                    ilGenerator.Emit(OpCodes.Ldarg_0);
                    ilGenerator.Emit(OpCodes.Call, getMethod);

                    // 添加更多自定义逻辑
                    ilGenerator.Emit(OpCodes.Ldstr, "After original logic");
                    ilGenerator.Emit(OpCodes.Call, typeof(Debugger).GetMethod("Warn", new Type[] { typeof(string) }));

                    ilGenerator.Emit(OpCodes.Ret);

                    propertyBuilder.SetGetMethod(getMethodBuilder);
                }

                var setMethod = property.GetSetMethod();
                if (setMethod != null)
                {
                    var setMethodBuilder = typeBuilder.DefineMethod(
                        "set_" + property.Name,
                        //MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                        setMethod.Attributes,
                        null,
                        new[] { property.PropertyType });

                    var ilGenerator = setMethodBuilder.GetILGenerator();

                    // 添加更多自定义逻辑
                    ilGenerator.Emit(OpCodes.Ldstr, "Before original logic");
                    ilGenerator.Emit(OpCodes.Call, typeof(Debugger).GetMethod("Warn", new Type[] { typeof(string) }));

                    ilGenerator.Emit(OpCodes.Ldarg_0);
                    ilGenerator.Emit(OpCodes.Ldarg_1);
                    ilGenerator.Emit(OpCodes.Call, setMethod);

                    // 插入额外逻辑
                    ilGenerator.Emit(OpCodes.Ldstr, "Setting property: " + property.Name);
                    ilGenerator.Emit(OpCodes.Call, typeof(Debugger).GetMethod("Warn", new[] { typeof(string) }));

                    ilGenerator.Emit(OpCodes.Ret);

                    propertyBuilder.SetSetMethod(setMethodBuilder);
                }
            }

            var proxyType = typeBuilder.CreateType();
            return (T) Activator.CreateInstance(proxyType, true);
        }
    }
}
