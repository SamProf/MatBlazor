using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Helpers
{
    public class ClassMapper
    {
        private string _class;
        private bool _dirty = true;

        public string Class
        {
            get
            {
                if (_dirty)
                {
                    _class = string.Join(" ", map.Where(i => i.Value()).Select(i => i.Key()));
                }

                return _class;
            }
        }


        private Dictionary<Func<string>, Func<bool>> map = new Dictionary<Func<string>, Func<bool>>();


        public void MakeDirty()
        {
            _dirty = true;
        }

        public ClassMapper Add(string name)
        {
            map.Add(() => name, () => true);
            return this;
        }


        public ClassMapper Get(Func<string> funcName)
        {
            map.Add(funcName, () => true);
            return this;
        }

        public ClassMapper GetIf(Func<string> funcName, Func<bool> func)
        {
            map.Add(funcName, func);
            return this;
        }

        public ClassMapper If(string name, Func<bool> func)
        {
            map.Add(() => name, func);
            return this;
        }
    }
}