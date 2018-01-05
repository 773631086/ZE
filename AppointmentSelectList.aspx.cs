using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumeralSceneMakeJy
{
    public partial class AppointmentSelectList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListData();
                //   this.hidDay.Value = GetQueryOrForms("time");
            }
        }
        public string time
        {
            get
            {
                return GetQueryOrForms("time");
            }
        }
        public string AppProjectId
        {
            get
            {
                return GetQueryOrForms("AppProjectId");
            }
        }
        public string DeptId
        {
            get
            {
                return GetQueryOrForms("DeptId");
            }
        }
        private void ListData()
        {

            List<Oos.Numeral.Model.Numeral_Appointment> list = new Oos.Numeral.Bll.Numeral_Appointment().getXCYYList(AppProjectId, DeptId, DateTime.Parse(time+" "+GetQueryOrForms("Statime")), DateTime.Parse(time+" "+GetQueryOrForms("endTime"))); //获取预约情况
            rptDept.DataSource = list;
            rptDept.DataBind();
        }
    }
}