using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public sealed class Singleton
    {
        private Singleton()
        { }

        private static readonly Singleton instance = new Singleton();

        public static Singleton Instance
        {
            get { return instance; }
        }
    }
}