using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumeralSceneMakeJy.Ajax
{
    public partial class AjaxOnLineDate : BasePage
    {
        Oos.Numeral.Bll.xc_appproject appBll = new Oos.Numeral.Bll.xc_appproject();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Action = GetQueryOrForms("Action");
            if (Action == "GetDeptidList")
            {
                GetDeptIdList();
            }

            else if (Action == "SelectAppProject")
            {
                SelectAppProject();
            }
            else if (Action == "selectDay")
            {
                selectDay(GetQueryOrForms("years"), GetQueryOrForms("month"), GetQueryOrForms("DeptId"), GetQueryOrForms("AppProjectId"));
            }
            else if (Action == "undo")
            {
                undo();
            }
            Response.End();
        }
        public void GetDeptIdList()
        {
            string status = "0";
            string msg = "";
            string data = "[]";
            try
            {
                DataTable dt = appBll.GetDeptIdList();
                StringBuilder sbdata = new StringBuilder();
                sbdata.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        sbdata.Append("{\"DeptId\":\"" + dt.Rows[i]["DeptId"] + "\"," + "\"DeptName\":\"" + dt.Rows[i]["DeptName"] + "\"}");
                    }
                    else
                    {
                        sbdata.Append(",{\"DeptId\":\"" + dt.Rows[i]["DeptId"] + "\"," + "\"DeptName\":\"" + dt.Rows[i]["DeptName"] + "\"}");

                    }
                }
                 sbdata.Append("]");
                data = sbdata.ToString();
                status = "1";
                msg = "执行成功！";
            }
            catch (Exception ex)
            {
                status = "0";
                msg = "异常";
            }


            Response.Write("{\"status\": " + status + ",\"msg\":\"" + msg + "\",\"data\":" + data + "}");
            Response.End();
        }

        public void SelectAppProject()
        {
            string status = "0";
            string msg = "";
            string data = "[]";
            try
            {
                StringBuilder sbdata = new StringBuilder();
                sbdata.Append("[");
                DataTable dt = appBll.GetDeptidList(GetQueryOrForms("ddlDept"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        sbdata.Append("{\"AppProjectCodeID\":\"" + dt.Rows[i]["AppProjectId"] + "\"," + "\"AppProjectName\":\"" + dt.Rows[i]["AppProjectName"] + "\"}");
                    }
                    else
                    {
                        sbdata.Append(",{\"AppProjectCodeID\":\"" + dt.Rows[i]["AppProjectId"] + "\"," + "\"AppProjectName\":\"" + dt.Rows[i]["AppProjectName"] + "\"}");

                    }
                }
                sbdata.Append("]");
                data = sbdata.ToString();
                status = "1";
                msg = "执行成功！";
            }
            catch (Exception ex)
            {
                status = "0";
                msg = "异常";
            }

            Response.Write("{\"status\": " + status + ",\"msg\":\"" + msg + "\",\"data\":" + data + "}");
            Response.End();
        }

        public void selectDay(string years, string month,string DeptId, string AppProjectId)
        {
            string status = "0";
            string msg = "";
            string data = "[]";
      
            try
            {
                Oos.Numeral.Bll.xc_blackandwhitelist bwBll = new Oos.Numeral.Bll.xc_blackandwhitelist();
                Oos.Numeral.Bll.xc_weekscycle wsBll = new Oos.Numeral.Bll.xc_weekscycle();
                Oos.Numeral.Bll.Numeral_Appointment appointmentBll = new Oos.Numeral.Bll.Numeral_Appointment();
                Oos.Numeral.Bll.xc_detpmaketime detpmaketimeBll = new Oos.Numeral.Bll.xc_detpmaketime();
                Oos.Systems.Bll.Systems_WorkDayManager WorkDayManagerBll = new Oos.Systems.Bll.Systems_WorkDayManager();
                StringBuilder str = new StringBuilder();
                str.Append("[");
                int dayOf = int.Parse(DateTime.Parse(years + "-" + month + "-" + "01").DayOfWeek.ToString("d"));
                for (int i = 0; i < dayOf; i++)
                {
                    if (i == 0)
                    {
                        str.Append("{\"day\": \"\", \"type\": \"\",\"select\": \"\", \"num\": \"\", \"total\": \"\" }");
                    }
                    else
                    {
                        str.Append(",{\"day\": \"\", \"type\": \"\",\"select\": \"\", \"num\": \"\", \"total\": \"\" }");
                    }
                }
                int MonthDay = DateTime.DaysInMonth(int.Parse(years), int.Parse(month));
                DateTime strTime = DateTime.Parse(int.Parse(years) + "-" + int.Parse(month) + "-01"+" 00:00:00");
                DateTime endTime = DateTime.Parse(int.Parse(years) + "-" + int.Parse(month) + "-01" + " 23:59:59").AddMonths(1).AddDays(-1);
                if (AppProjectId.Trim().Length == 0)
                {
                    for (int i = 1; i <= MonthDay; i++)
                    {
                     
                        if (dayOf == 0 && i == 1)
                        {
                            str.Append("{\"day\": \"" + i + "\", \"type\": \"\",\"select\": \"\", \"num\": \"\", \"total\": \"\" }");
                        }
                        else
                        {
                            str.Append(",{\"day\": \"" + i + "\", \"type\": \"\",\"select\": \"\", \"num\": \"\", \"total\": \"\" }");
                        }

                    }
                }
                else
                {
                    List<Oos.Numeral.Model.xc_blackandwhitelist> bwlist = bwBll.GetTimeList(AppProjectId, DeptId, strTime, endTime); //获取黑白名单
                    List<Oos.Numeral.Model.xc_weekscycle> scyclelistW = wsBll.GetList(AppProjectId, DeptId, 1); //获取周期周时间
                    List<Oos.Numeral.Model.xc_weekscycle> scyclelistM = wsBll.GetList(AppProjectId, DeptId, 2);//获取周期月时间
                    List<Oos.Numeral.Model.Numeral_Appointment> Appointmentlist = appointmentBll.getXCYYList(AppProjectId, DeptId, strTime, endTime); //获取预约情况
                    List<Oos.Numeral.Model.xc_detpmaketime> DeptMaketimeList = detpmaketimeBll.GetObjectIdList(AppProjectId, "2");  //获取时间段的总数
                    List<Oos.Systems.Model.Systems_WorkDayManager> WorkDayManagerList1 = WorkDayManagerBll.GetOrganIdList(OrganId, 0); //放假日期
                    List<Oos.Systems.Model.Systems_WorkDayManager> WorkDayManagerList2 = WorkDayManagerBll.GetOrganIdList(OrganId, 1); //上班日期
                    if (DeptMaketimeList.Count == 0)
                    {
                        DeptMaketimeList = detpmaketimeBll.GetObjectIdList(OrganId, "1");
                    }
                    int total = sumtotal(DeptMaketimeList);
                    for (int i = 1; i <= MonthDay; i++)
                    {
                        DateTime time = DateTime.Parse((int.Parse(years) + "-" + int.Parse(month) + "-" + i.ToString().PadLeft(2, '0')));
                        int type = 0; //是否可预约，0不可以，1可以
                        int select = 0;

                        if (isMakeApp(bwlist, scyclelistW, scyclelistM, time, WorkDayManagerList1, WorkDayManagerList2))
                        {
                            type = 1;
                        }
                        if (time < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")))
                        {
                            select = 1;
                        }

                        int num = SumNum(Appointmentlist, time);



                        if (dayOf == 0 && i == 1)
                        {
                            str.Append("{\"day\": \"" + i + "\", \"type\": \"" + type + "\", \"select\": \"" + select + "\", \"num\": \"" + num + "\" , \"total\": \"" + total + "\"  }");
                        }
                        else
                        {
                            str.Append(",{\"day\": \"" + i + "\", \"type\": \"" + type + "\", \"select\": \"" + select + "\", \"num\": \"" + num + "\" , \"total\": \"" + total + "\"  }");
                        }

                    }
                }

                for (int i = 0; i < 42 - dayOf - MonthDay; i++)
                {
                    str.Append(",{\"day\": \"\", \"type\": \"\", \"select\": \"\", \"num\": \"\", \"total\": \"\" }");
                }
                str.Append("]");
                status = "1";
                msg = "执行成功";
                data = str.ToString();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            Response.Write("{\"status\": " + status + ",\"msg\":\"" + msg + "\",\"data\":" + data + "}");
            Response.End();
        }
        //判断当天是否可以预约
        public bool isMakeApp(List<Oos.Numeral.Model.xc_blackandwhitelist> bwlist, List<Oos.Numeral.Model.xc_weekscycle> scyclelistW, List<Oos.Numeral.Model.xc_weekscycle> scyclelistM, DateTime time, List<Oos.Systems.Model.Systems_WorkDayManager> WorkDayManagerList1, List<Oos.Systems.Model.Systems_WorkDayManager> WorkDayManagerList2)
        {
            bool ismake = false;
            foreach (Oos.Numeral.Model.xc_blackandwhitelist model in bwlist)
            {
                if (DateTime.Parse(model.Settime.ToString()).ToString("yyyy-MM-dd 00:00:00") == time.ToString("yyyy-MM-dd 00:00:00"))
                {
                    if (model.type == 1)
                    {
                        ismake = true;
                        return ismake;
                    }
                    else if (model.type == 2)
                    {
                        return ismake;
                    }
                }
            }

            foreach (Oos.Numeral.Model.xc_weekscycle model in scyclelistW)
            {
                int day = Convert.ToInt32(time.DayOfWeek.ToString("d"));
                if (day == 0)
                {
                    day = 7;
                }
                if (model.CycleNum == day + "")
                {

                    foreach (Oos.Systems.Model.Systems_WorkDayManager Wmmodel in WorkDayManagerList1)
                    {
                        if (Wmmodel.WorkDate.ToString("yyyy-MM-dd") == time.ToString("yyyy-MM-dd"))
                        {
                            ismake = false;
                            return ismake;
                        }
                    }

                    ismake = true;
                    return ismake;
                }
            }

            foreach (Oos.Numeral.Model.xc_weekscycle model in scyclelistM)
            {

                //if (model.CycleNum.PadLeft(2,'0') == time.ToString("dd"))
                //{
                //    ismake = true;
                //    return ismake;
                //}
                if (model.CycleNum.PadLeft(2, '0') == time.ToString("dd"))
                {
                    int dayOf = int.Parse(time.DayOfWeek.ToString("d"));  //计算周日和节假日
                    if (dayOf == 0 || dayOf == 6)
                    {
                        foreach (Oos.Systems.Model.Systems_WorkDayManager Wmmodel in WorkDayManagerList2)
                        {
                            if (Wmmodel.WorkDate.ToString("yyyy-MM-dd") == time.ToString("yyyy-MM-dd"))
                            {
                                ismake = true;
                                return ismake;
                            }
                        }
                        ismake = false;
                        return ismake;
                    }
                    else
                    {
                        foreach (Oos.Systems.Model.Systems_WorkDayManager Wmmodel in WorkDayManagerList1)
                        {
                            if (Wmmodel.WorkDate.ToString("yyyy-MM-dd") == time.ToString("yyyy-MM-dd"))
                            {
                                ismake = false;
                                return ismake;
                            }
                        }
                        ismake = true;
                        return ismake;
                    }



                }
            }


            return ismake;
        }

        //个数
        public int SumNum(List<Oos.Numeral.Model.Numeral_Appointment> Appointmentlist, DateTime time)
        {
            int sum = 0;

            foreach (Oos.Numeral.Model.Numeral_Appointment model in Appointmentlist)
            {
                if (model.AppointmentStatTime.ToString("yyyy-MM-dd 00:00:00") == time.ToString("yyyy-MM-dd 00:00:00")&&model.IsTake<2)
                {
                    sum++;
                }
            }

            return sum;

        }
        //总数
        public int sumtotal(List<Oos.Numeral.Model.xc_detpmaketime> DeptMaketimeList)
        {
            int sum = 0;
            foreach (Oos.Numeral.Model.xc_detpmaketime model in DeptMaketimeList)
            {
                if (int.Parse(model.Reserved2.ToString()) < 0)
                {
                    sum = int.Parse(model.Reserved2.ToString());
                    return sum;
                }
                else
                {
                    sum = sum + int.Parse(model.Reserved2.ToString());
                }
                
            }
            return sum;
        }

        public void undo()
        {
            string str = "0";
            Oos.Numeral.Bll.Numeral_Appointment detTimeBll = new Oos.Numeral.Bll.Numeral_Appointment();
            Oos.Numeral.Model.Numeral_Appointment detModel = detTimeBll.GetModel(GetQueryOrForms("KeyValue"));
            if (detModel != null)
            {
                detModel.IsTake = 2;
                if (detTimeBll.Update(detModel))
                {
                    str = "y";
                }

            }
            Response.Write(str);
            Response.End();
        }
    }
}