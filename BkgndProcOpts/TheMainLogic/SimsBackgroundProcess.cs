using System;
using System.Collections.Generic;

namespace TheMainLogic
{
    public abstract class SimsBackgroundProcess: IDisposable
    {
        //initialize [protected]
        //validate [protected]
        //execute [public]
        //dispose [protected]

        protected Dictionary<string, dynamic> _configuration;
        /// <summary>
        /// All initialization code goes here
        /// </summary>
        protected abstract void Initialize();
        /// <summary>
        /// Pass configuration settings here
        /// </summary>
        /// <param name="configuration">Collection of Key-value pairs of configuration settings</param>
        public virtual void Configure(Dictionary<string, dynamic> configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Validate configuration
        /// </summary>
        /// <returns>false by default</returns>
        protected abstract bool Validate();

        /// <summary>
        /// Do the actual processing here
        /// </summary>
        public void LongProcess()
        {
            if (!Validate())
                throw new InvalidOperationException("Process validation failed!!");

            Initialize();
            Execute();
            Dispose();
        }

        protected abstract void Execute();
        /// <summary>
        /// All cleanup code goes here
        /// </summary>
        protected abstract void Dispose();

        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}
