using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumeralSceneMakeJy
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YearsAndmonthLoading();
                if (ddlyears.Items.FindByValue(DateTime.Now.ToString("yyyy")) != null && ddlMonth.Items.FindByValue(DateTime.Now.ToString("MM")) != null)
                {
                    ddlyears.Items.FindByValue(DateTime.Now.ToString("yyyy")).Selected = true;
                    ddlMonth.Items.FindByValue(DateTime.Now.ToString("MM")).Selected = true;
                }
            }
        }

   

    

        public void YearsAndmonthLoading()
        {
            int year = int.Parse(DateTime.Now.ToString("yyyy"));

            for (int i = -2; i <= 10; i++)
            {
                ddlyears.Items.Add(new ListItem(year + i + "年", year + i + ""));
            }

            for (int i = 1; i < 13; i++)
            {
                ddlMonth.Items.Add(new ListItem(i.ToString().PadLeft(2, '0')+"月", i.ToString().PadLeft(2, '0')));
            }



        }
    }
}