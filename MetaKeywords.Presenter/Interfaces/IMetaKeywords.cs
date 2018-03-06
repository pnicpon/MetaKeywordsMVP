using MetaKeywords.DataModel.Types;
using System.Collections.Generic;

public delegate void VoidHandler();

namespace MetaKeywords.Presenter.Interfaces
{   
    public interface IMetaKeywords
    {
        string Url { get; }

        event VoidHandler GetSearchResult;

        List<MetaKeyword> MetaKeywords { set; }
    }
}
