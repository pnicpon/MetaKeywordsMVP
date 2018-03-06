using MetaKeywords.DataModel.Resources;
using MetaKeywords.DataModel.Types;
using MetaKeywords.Presenter;
using MetaKeywords.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetaKeywords.Views
{
    public partial class MainView : System.Web.UI.Page, IMetaKeywords
    {
        #region Private variables

        private List<MetaKeyword> searchResult = new List<MetaKeyword>();
        private MetaKeywordsPresenter presenter;

        #endregion

        #region Event Handlers

        /// <summary>
        /// page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblHeader.Text = StaticTexts.MetaKeywords;
                cbShowPage.Text = StaticTexts.ShowPage;
                btnGetSearchResult.Text = StaticTexts.CheckMetaKeywords;
                rfvUrl.ErrorMessage = StaticTexts.UrlValidationMessage;

                gridResult.Columns[0].HeaderText = StaticTexts.MetaKeyword;
                gridResult.Columns[1].HeaderText = StaticTexts.Count;
            }
        }

        /// <summary>
        /// Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetSearchResult_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize presenter
                InitPresenter();

                // Raise event 
                if (GetSearchResult != null)
                    GetSearchResult();

                if (searchResult != null && searchResult.Count != 0)
                {
                    // Show result
                    pnlResult.Visible = true;
                    pnlMessage.Visible = false;

                    gridResult.DataSource = searchResult;
                    gridResult.DataBind();

                    if (cbShowPage.Checked)
                    {
                        framePreview.Src = Url;
                        pnlPreview.Visible = true;
                    }
                    else
                        pnlPreview.Visible = false;
                }
                else
                    ShowMessage(StaticTexts.NoResult);
            }
            catch (Exception)
            {
                ShowMessage(StaticTexts.GetPageError);
            }
        }

        #endregion

        #region IMetaKeywords Members

        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            get { return txtUrl.Text; }
        }
        
        /// <summary>
        /// Get Search Event
        /// </summary>
        public event VoidHandler GetSearchResult;

        /// <summary>
        /// Search result list from Presenter
        /// </summary>
        public new List<MetaKeyword> MetaKeywords
        {
            set { searchResult = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check if presenter is there initialize
        /// </summary>
        private void InitPresenter()
        {
            if (presenter == null)
                presenter = new MetaKeywordsPresenter(this);
        }

        private void ShowMessage(string message)
        {
            pnlMessage.Visible = true;
            pnlResult.Visible = pnlPreview.Visible = false;

            ltrMessage.Text = message;
        }

        #endregion
    }
}