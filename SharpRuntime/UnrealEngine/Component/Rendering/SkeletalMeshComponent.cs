using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnrealEngine
{
    public class SkeletalMeshComponent : SkinnedMeshComponent
    {
        public float GlobalAnimRateScale
        {
            get { return _GetGlobalAnimRateScale(NativeHandler); }
            set { _SetGlobalAnimRateScale(NativeHandler, value); }
        }

        public void Play(bool looping)
        {
            _Play(NativeHandler, looping);
        }

        public void Stop()
        {
            _Stop(NativeHandler);
        }

        public bool IsPlaying
        {
            get { return _GetIsPlaying(NativeHandler); }
        }


        public float PlayRate
        {
            get;
            set;
        }

        public void SetEnableBodyGravity(bool bEnableGravity, string BoneName)
        {
            _SetEnableBodyGravity(NativeHandler, bEnableGravity, BoneName);
        }

        public bool IsBodyGravityEnabled(string BoneName)
        {
            return _IsBodyGravityEnabled(NativeHandler, BoneName);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static float _GetGlobalAnimRateScale(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _SetGlobalAnimRateScale(IntPtr handler, float value);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _Play(IntPtr handler, bool looping);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _Stop(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static bool _GetIsPlaying(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static float _GetPlayRate(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _SetPlayRate(IntPtr handler, float value);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _SetEnableBodyGravity(IntPtr handler, bool bEnableGravity, string BoneName);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static bool _IsBodyGravityEnabled(IntPtr handler, string BoneName);

    }
}