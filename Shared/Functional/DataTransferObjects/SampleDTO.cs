namespace Nagarro.Sample.Shared
{
    [EntityMapping("Sample", MappingType.TotalExplicit)]
    public class SampleDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "SampleProperty1")]//There is no entity like Sample that exists
        public int SampleProperty1 { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "SampleProperty3")]
        public string SampleProperty2 { get; set; }
    }
}
