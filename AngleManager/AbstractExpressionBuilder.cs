using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager
{
    
    /// <summary>
    /// An abstract base class for implementation of the expression builder design pattern
    /// which facilitates concisely building objects with a fluent interface.
    /// </summary>
    public abstract class AbstractExpressionBuilder
    {
        private bool _buildingComplete;

        protected void SetBuildingComplete()
        {
            VerifyBuildingState();
            _buildingComplete = true;
        }

        protected void VerifyBuildingState()
        {
            if (_buildingComplete)
            {
                //TODO : Localize the string message
                throw new InvalidOperationException("This [" + GetType().Name + "] is done building the object and cannot be modified.");
            }
        }

        protected bool IsBuildingComplete() { return _buildingComplete; }
    }
}
