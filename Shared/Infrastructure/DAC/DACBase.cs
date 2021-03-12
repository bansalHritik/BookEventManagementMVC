namespace Nagarro.Sample.Shared
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;

    public abstract class DACBase : IDataAccessComponent
    {

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="DACBase"/> class.
        /// </summary>
        /// <param name="dacType">Type of the dac.</param>
        protected DACBase(DACType dacType)
        {
            this.Type = dacType;
        }
        #endregion

        #region IDataAccessComponent Members

        /// <summary>
        /// private gets the type of the DAC.
        /// </summary>
        /// <value>The type of the DAC.</value>
        public DACType Type { get; private set; }

        #endregion

    }
}
