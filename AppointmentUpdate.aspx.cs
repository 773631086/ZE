using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumeralSceneMakeJy
{
    public partial class AppointmentUpdate : BasePage
    {
        Oos.Numeral.Bll.Numeral_Appointment BllNumApp = new Oos.Numeral.Bll.Numeral_Appointment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Oos.Numeral.Model.Numeral_Appointment model = BllNumApp.GetModel(GetQueryOrForms("ID"));
                if (model != null)
                {
                    this.txtName.Text = model.AppointmentName;
                    this.txtPhone.Text = model.AppointmentTel;
                    this.txtIdcard.Text = model.AppointmentCard;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim().Length == 0 || this.txtName.Text.Trim() == "")
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
            else
            {
                Oos.Numeral.Model.Numeral_Appointment model = BllNumApp.GetModel(GetQueryOrForms("ID"));
                if (model != null)
                {
                    model.AppointmentName = this.txtName.Text;
                    model.AppointmentTel = this.txtPhone.Text;
                    model.AppointmentCard = this.txtIdcard.Text;
                    BllNumApp.Update(model);
                }
               // Alert("身份信息变更成功！");
                string pringTxt = Selectprint(model.Reserved2);
                pringTxt = pringTxt.Replace("[预约人]", this.txtName.Text.Trim()).Replace("[预约码]", model.AppointmentVerification).Replace("[手机号]", this.txtPhone.Text).Replace("[身份证号]", this.txtIdcard.Text)
                    .Replace("[预约开始时间]", model.AppointmentStatTime.ToString("yyyy-MM-dd HH:mm:00")).Replace("[预约结束时间]", model.AppointmentEndTime.ToString("yyyy-MM-dd HH:mm:00"))
                    .Replace("[暗记]", Memorization(model.CreateDate, this.txtIdcard.Text)).Replace("[申请时间]", model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("[预约业务]", model.AppointmentAppProject);



            
                AlertAndClose("身份信息变更成功！", ToBase64(pringTxt));
            }
        }
        /// <summary>
        /// 弹出提示消息并关闭当前页
        /// </summary>
        /// <param name="Mess">提示消息</param>
        public void AlertAndClose(string Mess, string print)
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