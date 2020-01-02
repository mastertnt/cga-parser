using System;
using System.Collections.Generic;

namespace CGACompute
{
    public class Context
    {
        private Dictionary<string, Shape> mShapes = new Dictionary<string, Shape>();

        public void SetVariable(string pName, Shape pShape)
        {
            Shape lResult;
            if (this.mShapes.TryGetValue(pName, out lResult) == false)
            {
                this.mShapes.Add(pName, pShape);
                return;
            }
            throw new NotSupportedException();
        }
        

        public Shape GetVariable(string pName)
        {
            Shape lResult;
            if (this.mShapes.TryGetValue(pName, out lResult))
            {
                return lResult;
            }

            return null;
        }
    }
}
