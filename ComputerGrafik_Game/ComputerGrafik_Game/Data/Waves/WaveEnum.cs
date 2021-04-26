using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafik_Game.Data.Waves
{
    public sealed class WaveEnum
    {
        private static readonly int wave1count = 10;
        private static readonly double wave1health = 100;
        private static readonly float wave1speed = 1.0f;

        private static readonly int wave2count = 15;
        private static readonly double wave2health = 105;
        private static readonly float wave2speed = 1.02f;

        private static readonly int wave3count = 20;
        private static readonly double wave3health = 110;
        private static readonly float wave3speed = 1.05f;

        private static readonly int wave4count = 30;
        private static readonly double wave4health = 115;
        private static readonly float wave4speed = 1.07f;

        private static readonly int wave5count = 40;
        private static readonly double wave5health = 120;
        private static readonly float wave5speed = 1.10f;


        public static readonly int[] countArray = new int[] { wave1count, wave2count, wave3count, wave4count, wave5count };
        public static readonly double[] healthArray = new double[] { wave1health, wave2health, wave3health, wave4health, wave5health };
        public static readonly float[] speedArray = new float[] { wave1speed, wave2speed, wave3speed, wave4speed, wave5speed };
    }
}
