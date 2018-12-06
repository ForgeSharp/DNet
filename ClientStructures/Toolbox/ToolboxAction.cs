using System;

namespace DNet.ClientStructures
{
    public struct ToolboxAction
   {
        public delegate void ToolboxActionCallback(object result);

        /// <summary>
        /// The action that the toolbox will execute
        /// </summary>
        public Action Action { get; set; }

        /// <summary>
        /// The parameters to pass into the action
        /// </summary>
        public dynamic[] Parameters { get; set; }

        /// <summary>
        /// Used internally for handling action callbacks
        /// </summary>
        public ToolboxActionCallback Callback { get; set; }
    }
}
