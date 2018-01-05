using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumeralSceneMakeJy
{
    public partial class ChangeAppointmentList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListData();
                //   this.hidDay.Value = GetQueryOrForms("time");
            }
        }
        public string type
        {
            get
            {
                return GetQueryOrForms("type");
            }
        }
        public string val
        {
            get
            {
                return GetQueryOrForms("val");
            }
        }
        public string IdCard
        {
            get
            {
                return GetQueryOrForms("IdCard");
            }
        }
        private void ListData()
        {
            List<Oos.Numeral.Model.Numeral_Appointment> list = new List<Oos.Numeral.Model.Numeral_Appointment>();
            if (type == "1")
            {
                list = new Oos.Numeral.Bll.Numeral_Appointment().getAppointmentIdvalXc(val,OrganId); //获取预约情况

            }
            else if (type == "2")
            {
                list = new Oos.Numeral.Bll.Numeral_Appointment().getAppointmentIdCardXc(IdCard, OrganId); //获取预约情况
            }
            rptDept.DataSource = list;
            rptDept.DataBind();
        }
    }
}