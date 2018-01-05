using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumeralSceneMakeJy
{
    public partial class AppointmentAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Oos.Numeral.Bll.xc_appproject appBll = new Oos.Numeral.Bll.xc_appproject();
        Oos.Numeral.Bll.Numeral_Appointment BllApp = new Oos.Numeral.Bll.Numeral_Appointment();
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                object[] obj = new object[7];
                obj[0] = OrganId;
                obj[1] = GetQueryOrForms("AppProjectId");
                obj[2] = GetQueryOrForms("DeptId");
                obj[3] = this.txtPhone.Text;
                obj[4] = this.txtIdcard.Text;
                string[] sArray = GetQueryOrForms("time").Split('-');
                if (sArray.Length <= 1)
                {
                    AlertError("选择的日期无效，请重新选择！");
                }
                obj[5] = DateTime.Parse(GetQueryOrForms("time") + " " + GetQueryOrForms("Statime"));
                obj[6] = DateTime.Parse(GetQueryOrForms("time") + " " + GetQueryOrForms("endTime"));
               // string svalidation = iweb.ValidationAll(UserToken, obj);
                //     string svalidation = iweb.Validation(UserToken, OrganId, this.hidAppProjectId.Value, ZPLibrary.Check.ChkWord(this.txtPhone.Text), ZPLibrary.Check.ChkWord(this.txtIDCard.Text), DateTime.Parse(this.ddlDateTime.Text).AddHours(int.Parse(this.ddlTime.Text)));
                string svalidation = Validation(obj);
                if (GetQueryOrForms("DeptId") == "")
                {
                    AlertError("选择的部门无效，请重新选择！");
                }
                else if (GetQueryOrForms("AppProjectId") == "")
                {
                    AlertError("选择的事项无效，请重新选择！");
                }
                else if (this.txtName.Text.Trim().Length == 0 || this.txtName.Text.Trim() == "")
                {
                    AlertError("输入的名字不能为空！");
                }
                else if (!IsNumber(this.txtPhone.Text) || this.txtPhone.Text.Length != 11)
                {
                    AlertError("输入的手机号只能是11位数字！");
                }
                else if (this.txtIdcard.Text.Length != 18)
                {
                    AlertError("请输入正确的18位身份证号");
                }

                else if (svalidation.Length > 0)
                {
                    AlertError(svalidation);
                }
                else
                {
                    DateTime time=DateTime.Now;
                    string OrganListXml = AddNumeralAt(OrganId, GetQueryOrForms("AppProjectId"), GetQueryOrForms("DeptName"), this.txtName.Text, this.txtPhone.Text, this.txtIdcard.Text,
                        DateTime.Parse(obj[5].ToString()), DateTime.Parse(obj[6].ToString()), 5, time);
                    appBll.UpdateReserved3(GetQueryOrForms("AppProjectId"));
                    if (OrganListXml.Length == 6)
                    {
                        string SendContent = "尊敬的" + this.txtName.Text.Trim() + "，您成功预约了“" + this.hidAppProjectName.Value + "”业务，你的预约码是：" + OrganListXml + ",预约时间：" + DateTime.Parse(obj[5].ToString()).ToString("yyyy年MM月dd HH点mm分") +" 至 " +DateTime.Parse(obj[6].ToString()).ToString("yyyy年MM月dd HH点mm分")+ "。注：同一事项，同一身份证号只能预约一次；请带上预约时登记的身份证按时到现场取票，超过预约时间未取票，预约作废。";
                        // string SendContent = "欢迎使用江油市行政审批局预约功能，您的预约时间是" + DateTime.Parse(this.ddlDateTime.Text).AddHours(int.Parse(this.ddlTime.Text)) + "至" + DateTime.Parse(this.ddlDateTime.Text).AddHours(int.Parse(this.ddlTime.Text) + 1) + ";预约码是：" + OrganListXml + ",请到现场排队机上取票;注：超过预约时间未取票将作废处理";
                        //  iweb.AddWXWaitSendSms(UserToken, ZPLibrary.Check.ChkWord(this.txtPhone.Text), SendContent, "9acb1047-2d0c-48db-9a06-81ea59b428b9", "98493373-8051-4e65-9e35-5d39ca45608d", "48|000000000000000000000000000000000", this.hidAppProjectId.Value);
                        //try
                        //{
                        //    new WebSms.Sms().GysRsSendSms("9acb1047-2d0c-48db-9a06-81ea59b428b9", ZPLibrary.Check.ChkWord(this.txtPhone.Text), SendContent);
                        //    Alert(SendContent + "随后将发短信通知！");
                        //}
                        //catch (Exception ex)
                        //{
                        //    Alert(SendContent);
                        //}
                        string pringTxt = Selectprint(GetQueryOrForms("AppProjectId"));
                        pringTxt = pringTxt.Replace("[预约人]", this.txtName.Text.Trim()).Replace("[预约码]", OrganListXml).Replace("[手机号]", this.txtPhone.Text).Replace("[身份证号]", this.txtIdcard.Text)
                            .Replace("[预约开始时间]", DateTime.Parse(obj[5].ToString()).ToString("yyyy-MM-dd HH:mm:00")).Replace("[预约结束时间]", DateTime.Parse(obj[6].ToString()).ToString("yyyy-MM-dd HH:mm:00"))
                            .Replace("[暗记]", Memorization(time, this.txtIdcard.Text)).Replace("[申请时间]", time.ToString("yyyy-MM-dd HH:mm:ss")).Replace("[预约业务]", this.hidAppProjectName.Value);



                        AlertAndClose(SendContent, ToBase64(pringTxt));
                       
                        this.txtName.Text = "";
                        this.txtPhone.Text = "";
                        this.txtIdcard.Text = "";
                        //   this.hidAppProjectId.Value = "";
                        //  this.hidDeptID.Value = "";
                    }
                    else
                    {
                        AlertError("预约异常！请联系站长！");
                    }

                }
            
            }
            catch (Exception ex)
            {
                AlertError("预约异常！请联系站长！");
            }
        }

        public string Validation(object[] obj)
        {
            string str = "";

            Oos.Numeral.Bll.xc_appproject BllAppXc = new Oos.Numeral.Bll.xc_appproject();
            Oos.Numeral.Bll.Numeral_Appointment BllNumApp = new Oos.Numeral.Bll.Numeral_Appointment();
            List<Oos.Numeral.Model.xc_appproject> ListAppXc = BllAppXc.GetAppProjectIdList(obj[1].ToString());
            if (ListAppXc.Count > 0)
            {
                List<Oos.Numeral.Model.Numeral_Appointment> List = BllNumApp.getAppointmentTelAndCardXc(obj[3].ToString(), obj[4].ToString(), obj[0].ToString(), obj[1].ToString());
                if (List.Count >= ListAppXc[0].IDCradLimit && ListAppXc[0].IDCradLimit>0)
                {
                 //   str = "当前个人个数已经超过设置限制,已存在预约记录,预约的日期：";
                    str = "当前预约人员存在已预约信息，预约日期："  +List[0].AppointmentStatTime.ToString("yyyy-MM-dd HH:mm:00") + "，请作废后再预约";
                } 
                //else if (List.Count > 0)
                //{
                //    str = "预约的身份证或者手机号已经存在";
                //}
                Oos.Numeral.Model.xc_detpmaketime model = new Oos.Numeral.Bll.xc_detpmaketime().GetModel(GetQueryOrForms("XCDetpMakeTimeID"));
                string num = BllApp.GetXCYYApprovedCountPersonal(OrganId, "", obj[1].ToString(), DateTime.Parse(obj[5].ToString()), DateTime.Parse(obj[6].ToString()));
                if (model.Reserved2 >= 0)
                {
                    if (model.Reserved2 - int.Parse(num)<=0)
                    {
                        str = "当前预约的个数已经超过设置限制";
                    }
                }

            }
            else
            {
                str = "未获取到配置的事项";
            }



            return str;
        }

      

        public string AddNumeralAt( string OrganId, string AppProjectId, string AppointmentDeptName, string AppointmentName, string AppointmentTel, string AppointmentCard, DateTime AppointmentStatTime, DateTime AppointmentEndTime, int AppointmentType,DateTime time)
        {

            //OrganId = "131|00000000000000000000000000000000";
            string results = "";
       
           // DateTime newTime = DateTime.Now;
            Oos.Numeral.Bll.AppProject BAppProject = new Oos.Numeral.Bll.AppProject();
            Oos.Numeral.Bll.Numeral_Appointment BNumeral_Appointment = new Oos.Numeral.Bll.Numeral_Appointment();

            List<Oos.Numeral.Model.AppProject> aptList = BAppProject.GetAppProjectCodeIDList(OrganId, AppProjectId);
            if (aptList != null & aptList.Count > 0)
            {



                Random ro = new Random();
                int i = ro.Next(100000, 1000000);
                while (BNumeral_Appointment.GetVER(i.ToString(), OrganId, DateTime.Now))
                {
                    i = ro.Next(100000, 1000000);
                }
                Oos.Numeral.Model.Numeral_Appointment model = new Oos.Numeral.Model.Numeral_Appointment();
                model.ID = System.Guid.NewGuid().ToString();
                model.AppointmentAppProject = aptList[0].AppProjectName;
                model.AppointmentCard = AppointmentCard;
                model.AppointmentDeptId = aptList[0].AppObjectOrganCodeID;
                model.AppointmentDeptName = AppointmentDeptName;
                model.AppointmentEndTime = AppointmentEndTime;
                model.AppointmentName = AppointmentName;
                model.AppointmentStatTime = AppointmentStatTime;
                model.AppointmentTel = AppointmentTel;
                model.AppointmentType = AppointmentType;
                model.AppointmentVerification = i.ToString();
                model.CreateDate = time;
                model.IsTake = 0;
                model.OrganId = OrganId;
                model.Remark = "";
                model.Reserved1 = "";
                model.Reserved2 = aptList[0].AppProjectCodeID;
                model.Reserved3 = "";
                model.Reserved4 = "";
                model.Reserved5 = "";
                model.IsApproved = 1;
                if (BNumeral_Appointment.Add(model))
                {
                    results = i.ToString();
                }

            }
            return results;
        }

        /// <summary>
        /// 弹出提示消息并关闭当前页
        /// </summary>
        /// <param name="Mess">提示消息</param>
        public void AlertAndClose(string Mess,string print)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "try{ $.System.Alert('" + Mess + "');parent.PageReload();window.external.print(\"" + print + "\"); } catch (ex) { }", true);
        }


        public string Selectprint(string AppProjectId)
        {
            string pringTxt = "";
            Oos.Numeral.Bll.xc_appproject Bll = new Oos.Numeral.Bll.xc_appproject();
            List<Oos.Numeral.Model.xc_appproject> AppList = Bll.GetAppProjectIdList(AppProjectId);
            if (AppList.Count > 0)
            {
                pringTxt = AppList[0].PrintText;
            }
            return pringTxt;
        }
    }
}