using System.Collections.Generic;

namespace RestApi.Data.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
