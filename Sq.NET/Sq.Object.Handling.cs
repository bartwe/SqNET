using System;
using System.Runtime.InteropServices;

namespace Squirrel
{
    public static partial class Sq
    {
        [DllImport(DllName, EntryPoint = "sq_bindenv")]
        extern public static int BindEnv(IntPtr v, int idx);

        [DllImport(DllName, EntryPoint = "sq_createinstance")]
        extern public static int CreateInstance(IntPtr v, int idx);

        [DllImport(DllName, EntryPoint = "sq_getbool")]
        extern public static int GetBool(IntPtr v, int idx, out bool b);

        [DllImport(DllName, EntryPoint = "sq_getbyhandle")]
        extern public static int GetByHandle(IntPtr v, int idx, IntPtr handle);

        [DllImport(DllName, EntryPoint = "sq_getclosureinfo")]
        extern public static int GetClosureInfo(IntPtr v, int idx, out uint nparams, out uint nfreevars);

        [DllImport(DllName, EntryPoint = "sq_getclosurename")]
        extern public static int GetClosureName(IntPtr v, int idx);

        [DllImport(DllName, EntryPoint = "sq_getfloat")]
#if SQUSEDOUBLE
        extern public static int GetFloat(IntPtr v, int idx, out double f);
        public static int GetDouble(IntPtr v, int idx, out double f) => GetFloat(v, idx, out f);
#else
        extern public static int GetFloat(IntPtr v, int idx, out float f);
        public static int GetDouble(IntPtr v, int idx, out float f) => GetFloat(v, idx, out f);
#endif

        [DllImport(DllName, EntryPoint = "sq_gethash")]
        extern public static uint GetHash(IntPtr v, int idx);

        [DllImport(DllName, EntryPoint = "sq_getinstanceup")]
        extern public static int GetInstanceUserPointer(IntPtr v, int idx, out IntPtr up, IntPtr typetag);

        [DllImport(DllName, EntryPoint = "sq_getinteger")]
        extern public static int GetInteger(IntPtr v, int idx, out int i);

        [DllImport(DllName, EntryPoint = "sq_getmemberhandle")]
        extern public static int GetMemberHandle(IntPtr v, int idx, out IntPtr handle);

        [DllImport(DllName, EntryPoint = "sq_getscratchpad")]
        extern private static IntPtr NativeGetScratchPad(IntPtr v, int minsize);
        public static string GetScratchPad(IntPtr v, int minsize)
            => Marshal.PtrToStringUni(NativeGetScratchPad(v, minsize));

        [DllImport(DllName, EntryPoint = "sq_getsize")]
        extern public static int GetSize(IntPtr v, int idx);

        [DllImport(DllName, EntryPoint = "sq_getstring")]
        extern private static int NativeGetString(IntPtr v, int idx, out IntPtr c);

        public static int GetString(IntPtr v, int idx, out string c)
        {
            IntPtr ptr = IntPtr.Zero;
            int ret = NativeGetString(v, idx, out ptr);
            c = Marshal.PtrToStringUni(ptr);
            return ret;
        }

        [DllImport(DllName, EntryPoint = "sq_getthread")]
        extern public static int GetThread(IntPtr v, int idx, out IntPtr thread);

        [DllImport(DllName, EntryPoint = "sq_gettype")]
        extern public static ObjectType GetType(IntPtr v, int idx);

        [DllImport(DllName, EntryPoint = "sq_gettypetag")]
        extern public static int GetTypeTag(IntPtr v, int idx, out IntPtr typetag);

        [DllImport(DllName, EntryPoint = "sq_getuserdata")]
        extern public static int GetUserData(IntPtr v, int idx, out IntPtr p, out IntPtr typetag);

        [DllImport(DllName, EntryPoint = "sq_getuserpointer")]
        extern public static int GetUserPointer(IntPtr v, int idx, out IntPtr p);

        [DllImport(DllName, EntryPoint = "sq_newarray")]
        extern public static void NewArray(IntPtr v, int size);

        [DllImport(DllName, EntryPoint = "sq_newclass")]
        extern public static int NewClass(IntPtr v, bool hasbase);

        [DllImport(DllName, EntryPoint = "sq_newclosure")]
        extern private static void NativeNewClosure(IntPtr v, ISqFunction func, int nfreevars);
        public static void NewClosure(IntPtr v, SqFunction func, int nfreevars)
        {
            NativeNewClosure(v, (vm) =>
            {
                return func(new VM(vm));
            }, nfreevars);
        }

        [DllImport(DllName, EntryPoint = "sq_newtable")]
        extern public static void NewTable(IntPtr v);

        [DllImport(DllName, EntryPoint = "sq_newtableex")]
        extern public static void NewTableEx(IntPtr v, int initialcapacity);

        [DllImport(DllName, EntryPoint = "sq_newuserdata")]
        extern public static IntPtr NewUserData(IntPtr v, uint size);

        [DllImport(DllName, EntryPoint = "sq_pushbool")]
        extern public static void PushBool(IntPtr v, bool b);

        [DllImport(DllName, EntryPoint = "sq_pushfloat")]
#if SQUSEDOUBLE
        extern public static void PushFloat(IntPtr v, double f);
        public static void PushDouble(IntPtr v, double f) => PushFloat(v, f);
#else
        extern public static void PushFloat(IntPtr v, float f);
        public static void PushDouble(IntPtr v, float f) => PushFloat(v, f);
#endif

        [DllImport(DllName, EntryPoint = "sq_pushinteger")]
        extern public static void PushInteger(IntPtr v, int n);

        [DllImport(DllName, EntryPoint = "sq_pushnull")]
        extern public static void PushNull(IntPtr v);

        [DllImport(DllName, EntryPoint = "sq_pushstring")]
        extern public static void PushString(IntPtr v, [MarshalAs(StringType)] string s, int len);

        [DllImport(DllName, EntryPoint = "sq_pushuserpointer")]
        extern public static void PushUserPointer(IntPtr v, IntPtr p);

        [DllImport(DllName, EntryPoint = "sq_setbyhandle")]
        extern public static int SetByHandle(IntPtr v, int idx, IntPtr handle);

        [DllImport(DllName, EntryPoint = "sq_setclassudsize")]
        extern public static int SetClassUserDataSize(IntPtr v, int idx, int udsize);

        [DllImport(DllName, EntryPoint = "sq_setinstanceup")]
        extern public static int SetInstanceUserPointer(IntPtr v, int idx, IntPtr up);

        [DllImport(DllName, EntryPoint = "sq_setnativeclosurename")]
        extern public static int SetNativeClosureName(IntPtr v, int idx, [MarshalAs(StringType)] string name);

        [DllImport(DllName, EntryPoint = "sq_setparamscheck")]
        extern public static int SetParamsCheck(IntPtr v, int nparamscheck, [MarshalAs(StringType)] string typemask);

        [DllImport(DllName, EntryPoint = "sq_setreleasehook")]
        extern public static void SetReleaseHook(IntPtr v, int idx, SqReleaseHook hook);

        [DllImport(DllName, EntryPoint = "sq_settypetag")]
        extern public static int SetTypeTag(IntPtr v, int idx, IntPtr typetag);

        [DllImport(DllName, EntryPoint = "sq_tobool")]
        extern public static void ToBool(IntPtr v, int idx, out bool b);

        [DllImport(DllName, EntryPoint = "sq_tostring")]
        extern public static void ToString(IntPtr v, int idx);

        [DllImport(DllName, EntryPoint = "sq_typeof")]
        extern public static ObjectType TypeOf(IntPtr v, int idx);
    }
}