namespace Nagarro.Sample.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.Sample.Data.dll", "Nagarro.Sample.Data.SampleDAC")]
        SampleDAC = 1

    }
}
