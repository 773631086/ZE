using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumeralSceneMakeJy
{
    public partial class AppointmentTimeList : BasePage
    {
        Oos.Numeral.Bll.Numeral_Appointment BllApp = new Oos.Numeral.Bll.Numeral_Appointment();
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
        public int ListCount;
     
        private void ListData()
        {

            List<Oos.Numeral.Model.xc_detpmaketime> list = new Oos.Numeral.Bll.xc_detpmaketime().GetObjectIdList(AppProjectId, "2");
            if (list.Count == 0)
            {
                list = new Oos.Numeral.Bll.xc_detpmaketime().GetObjectIdList(OrganId, "1");
            }
            ListCount = list.Count;
            rptDept.DataSource = list;
            rptDept.DataBind();
        }

        public string Remai(string detpmaketimeId, string stTime, string endTime)
        {
            string TheDay = time;
            Oos.Numeral.Model.xc_detpmaketime model = new Oos.Numeral.Bll.xc_detpmaketime().GetModel(detpmaketimeId);
            if (model != null)
            {
                if (model.Reserved2 < 0)
                {
                    return "无限制";
                }
                else
                {
                    if (TheDay != "")
                    {
                        DateTime statTime = DateTime.Parse(TheDay + " " + stTime);
                        DateTime EndTime = DateTime.Parse(TheDay + " " + endTime);
                        string num = BllApp.GetXCYYApprovedCount(OrganId, "", AppProjectId, statTime, EndTime);

                        return (model.Reserved2 - int.Parse(num) <= 0) ? "0" : (model.Reserved2 - int.Parse(num) + "" + "个");

                    }
                    else
                    {
                        return "0个";
                    }
                }
            }
            else
            {
                return "0个";
            }
        }
    }
}