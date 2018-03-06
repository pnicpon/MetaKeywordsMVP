using MetaKeywords.BusinessLogic.Providers;
using MetaKeywords.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaKeywords.Presenter
{
    public class MetaKeywordsPresenter
    {
        IMetaKeywords _View;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="metaKeywords"></param>
        public MetaKeywordsPresenter(IMetaKeywords metaKeywords)
        {
            metaKeywords.GetSearchResult += new VoidHandler(_SearchResult);
            _View = metaKeywords;
        }

        /// <summary>
        /// Handler for search result event
        /// </summary>
        private void _SearchResult()
        {
            _View.MetaKeywords = SearchResultProvider.GetSearchResult(_View.Url);
        }
    }
}
