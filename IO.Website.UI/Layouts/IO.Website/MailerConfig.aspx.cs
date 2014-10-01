using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using IO.Website.UI.MVP.MailerConfig;
using IO.Website.UI.MVP;
using Microsoft.SharePoint.Utilities;
using System.Web;

namespace IO.Website.UI.Layouts.IO.Website
{
    public partial class MailerConfig : ExtendedLayoutsPage, IMailerConfigView
    {
        #region [Private Members]
        private MailerConfigPresenter _Presenter;
        #endregion

        #region [FormEvents]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _Presenter = new MailerConfigPresenter(this, SPContext.Current.Web);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            try { _Presenter.Load(); }
            catch (Exception ex) { HandleError(ex); }
        }

        protected void rdbUseAspNetMail_CheckedChanged(object sender, EventArgs e)
        {
            _Presenter.ShowAspNetMailParameters();
        }

        protected void rdbUseSharepointMailer_CheckedChanged(object sender, EventArgs e)
        {
            _Presenter.HideAspNetMailParameters();
            _Presenter.CleanAspNetMailParameters();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                _Presenter.Save();
                success = true;
            }
            catch (Exception ex) { HandleError(ex); }
            if (success)
                SPUtility.Redirect("/_layouts/15/settings.aspx", SPRedirectFlags.Default, HttpContext.Current);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SPUtility.Redirect("/_layouts/15/settings.aspx", SPRedirectFlags.Default, HttpContext.Current);
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                _Presenter.TestMailSettings();
                HandleSuccess("El correo electr&oacute;nico de prueba ha sido enviado exitosamente.");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        #endregion

        #region [IMailerConfigView]
        public bool UseSharepointDefaultConfig
        {
            get
            {
                return rdbUseSharepointMailer.Checked;
            }
            set
            {
                rdbUseSharepointMailer.Checked = value;
                rdbUseAspNetMail.Checked = !value;
                if (value) { _Presenter.HideAspNetMailParameters(); }
                else { _Presenter.ShowAspNetMailParameters(); }
            }
        }

        public bool UseSSL
        {
            get
            {
                return chkUseSSL.Checked;
            }
            set
            {
                chkUseSSL.Checked = value;
            }
        }

        public string MailServerAddress
        {
            get
            {
                return txtbServerAddress.Text;
            }
            set
            {
                txtbServerAddress.Text = value;
            }
        }

        public string UserName
        {
            get
            {
                return txtbLoginName.Text;
            }
            set
            {
                txtbLoginName.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return txtbPassword.Text;
            }
            set { txtbPassword.Text = value; }
        }

        public int Port
        {
            get { return string.IsNullOrEmpty(txtbPort.Text) ? 0 : Convert.ToInt32(txtbPort.Text); }
            set { txtbPort.Text = value.ToString(); }
        }

        public string InboundMailAddress
        {
            get
            {
                return txtbMailFromIn.Text;
            }
            set
            {
                txtbMailFromIn.Text = value;
            }
        }

        public string OutboundMailAddress
        {
            get
            {
                return txtbMailFromOut.Text;
            }
            set
            {
                txtbMailFromOut.Text = value;
            }
        }

        public void ShowAspNetMailParameters()
        {
            loginNameContainer.Visible = true;
            passwordConfirmContainer.Visible = true;
            passwordContainer.Visible = true;
            serverAddressContainer.Visible = true;
            serverportContainer.Visible = true;
            sslSecurityContainer.Visible = true;
        }

        public void HideAspNetMailParameters()
        {
            loginNameContainer.Visible = false;
            passwordConfirmContainer.Visible = false;
            passwordContainer.Visible = false;
            serverAddressContainer.Visible = false;
            serverportContainer.Visible = false;
            sslSecurityContainer.Visible = false;
        }
        #endregion

    }
}
