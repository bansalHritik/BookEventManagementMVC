namespace Nagarro.Sample.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.Sample.Business.dll", "Nagarro.Sample.Business.SampleBDC")]
        SampleBDC = 1

    }
}
