using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Xml;

namespace NumeralSceneMakeJy
{
    public class BasePage:System.Web.UI.Page
    {
        #region 系统配置信息
        /// <summary>
        /// 顶级机构Id
        /// </summary>
        public static string TopOrganId
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["OrganId"].ToString();
            }
        }
        /// <summary>
        /// 顶级机构名称
        /// </summary>
        public static string TopOrganName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["OrganName"].ToString();
            }
        }
        /// <summary>
        /// 顶级机构类型
        /// </summary>
        public static string TopOrganType
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["OrganType"].ToString();
            }
        }
        /// <summary>
        /// 超级管理名称
        /// </summary>
        public static string SuperAdmin
        {
            get
            {
                return "admin";
            }
        }
        /// <summary>
        /// 超级管理密码
        /// </summary>
        public static string SuperAdminPwd
        {
            get
            {
                return "123456";
            }
        }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["System"].ToString();
            }
        }
        #endregion
        /// <summary>
        /// 获取Url或Form提交的值
        /// </summary>
        /// <param name="KeyName">关键值名称</param>
        /// <returns></returns>
        public string GetQueryOrForms(string KeyName)
        {
            string KeyValue = Request.QueryString[KeyName];
            if (!string.IsNullOrEmpty(KeyValue))
                return KeyValue;
            KeyValue = Request.Form[KeyName];
            if (!string.IsNullOrEmpty(KeyValue))
                return KeyValue;
            return string.Empty;
        }
        /// <summary>
        /// 获取Url或Form提交的值
        /// </summary>
        /// <param name="KeyName">关键值名称</param>
        /// <param name="IsNullReaplceValue">为空时替换的值</param>
        /// <returns></returns>
        public string GetQueryOrForms(string KeyName, string IsNullReaplceValue)
        {
            string KeyValue = Request.QueryString[KeyName];
            if (!string.IsNullOrEmpty(KeyValue))
                return KeyValue;
            KeyValue = Request.Form[KeyName];
            if (!string.IsNullOrEmpty(KeyValue))
                return KeyValue;
            return IsNullReaplceValue;
        }
        /// <summary>
        /// 序列号ID
        /// </summary>
        /// <returns></returns>
        public string NewGuid()
        {
            return System.Guid.NewGuid().ToString().ToUpper();
        }
        public string DefaultParentNewId()
        {
            return new string('0', 36);
        }
        //弹出对话框///
        public void Alert(string Mess)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "')", true);
        }
        /// <summary>
        /// 异常提醒
        /// </summary>
        /// <param name="Mess"></param>
        public void AlertError(string Mess)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.ErrorAlert('" + Mess + "')", true);
        }
        public void Alert(string Mess, bool IsReload)
        {
            if (IsReload)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');parent.PageReload();", true);
            else
                Alert(Mess);
        }
        /// <summary>
        /// 弹出提示消息并关闭当前页
        /// </summary>
        /// <param name="Mess">提示消息</param>
        public void AlertAndClose(string Mess)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');parent.PageReload();DivClose();", true);
        }
        /// <summary>
        /// 弹出对话框
        /// </summary>
        /// <param name="Mess">提示消息</param>
        /// <param name="IsReload">是否刷新</param>
        /// <param name="RefreshControlId">刷新控件ID</param>
        public void Alert(string Mess, bool IsReload, string RefreshControlId)
        {
            if (IsReload)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');parent.PageReload('" + RefreshControlId + "');", true);
            else
                Alert(Mess);
        }
        public void AlertAndClose(string Mess, string RefreshControlId)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');parent.PageReload('" + RefreshControlId + "');DivClose();", true);
        }
        /// <summary>
        /// 刷新右下角子级页面
        /// </summary>
        /// <param name="Mess"></param>
        public void AlertAndSonClose(string Mess)
        {
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "'); parent.mainFrame.document.location.href = parent.mainFrame.document.location.href;DivClose();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "'); parent.window.frames[\"PannelMain\"].document.location.href = parent.window.frames[\"PannelMain\"].document.location.href;DivClose();", true);
        }
        /// <summary>
        /// 执行第二级Frame中单机事件
        /// </summary>
        /// <param name="Mess"></param>
        /// <param name="RefreshControlId"></param>
        public void AlertAndSonClose(string Mess, string RefreshControlId)
        {
          //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');  $(parent.window.frames[\"mainFrame\"].frames[\"iframeTabs\"].document).find(\"#" + RefreshControlId + "\").trigger(\"click\");DivClose();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');  $(parent.window.frames[\"PannelMain\"].document).find(\"#" + RefreshControlId + "\").trigger(\"click\");DivClose();", true);
        }
        /// <summary>
        /// 刷新三级frame 第一个ID是mainFrame，第二个是iframeTabs，第三个是List
        /// </summary>
        /// <param name="Mess"></param>
        public void AlertAndSonTwoClose(string Mess)
        {
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "'); parent.window.frames[\"mainFrame\"].frames[\"iframeTabs\"].frames[\"List\"].document.location.href = parent.window.frames[\"mainFrame\"].frames[\"iframeTabs\"].frames[\"List\"].document.location.href;DivClose();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "'); parent.window.frames[\"PannelMain\"].frames[\"List\"].document.location.href = parent.window.frames[\"PannelMain\"].frames[\"List\"].document.location.href;DivClose();", true);
        }
        /// <summary>
        /// 弹出对话框并关闭当前层
        /// </summary>
        /// <param name="Mess">弹出消息</param>
        /// <param name="IsRefreshParent">是否刷新</param>
        public void AlertAndClose(string Mess,bool IsRefreshParent)
        {
            if (IsRefreshParent)
                AlertAndClose(Mess);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');DivClose();", true);
        }
        //弹出对话框//返回URL地址，
        public void AlertRetrunGoUrl(string Mess,string url)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.AlertReturn('" + Mess + "',null,'" + url + "')", true);
        }
     /// <summary>
        /// 弹出对话框并刷新当前层
     /// </summary>
     /// <param name="Mess"></param>
        public void AlertIsRefresh(string Mess)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');PageReload();", true);
        }
        public void AlertAndCloseBlock(string Mess)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tips", "$.System.Alert('" + Mess + "');DivClose();parent.PageReload();", true);
        }
        public void ExecJs(string Js)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Js", Js, true);
        }
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="strValue">待加密的字符串</param>
        /// <returns></returns>
        public string Md5(string strValue)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strValue,"MD5");
        }
        public void WriteTextLog(string Mess)
        {
            string Path = Server.MapPath("~/SystemLog/"+DateTime.Now.Year.ToString());
            if (System.IO.Directory.Exists(Path))
                System.IO.Directory.CreateDirectory(Path);
            string FilePath = Path + "/Error.log";
            System.IO.FileInfo Fi = new System.IO.FileInfo(FilePath);
            if (!System.IO.Directory.Exists(Fi.DirectoryName))
                System.IO.Directory.CreateDirectory(Fi.DirectoryName);
            System.IO.FileStream fsText = System.IO.File.Open(FilePath, System.IO.FileMode.Append, System.IO.FileAccess.Write);
            byte[] byteMess = System.Text.Encoding.Default.GetBytes(DateTime.Now.ToString() + ":" + Mess + "\r\n");
            fsText.Seek(fsText.Length, System.IO.SeekOrigin.Begin);
            fsText.Write(byteMess, 0, byteMess.Length);
            fsText.Close();
            fsText.Dispose();
        }
        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public string GetClientIp()
        {
            string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ip == null || ip.Length == 0 || ip.ToLower().IndexOf("unknown") > -1)
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                if (ip.IndexOf(',') > -1)
                {
                    ip = ip.Substring(0, ip.IndexOf(','));
                }
                if (ip.IndexOf(';') > -1)
                {
                    ip = ip.Substring(0, ip.IndexOf(';'));
                }
            }
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9.]");
            if (ip == null || ip.Length == 0 || regex.IsMatch(ip))
            {
                ip = HttpContext.Current.Request.UserHostAddress;
                if (ip == null || ip.Length == 0 || regex.IsMatch(ip))
                {
                    ip = "0.0.0.0";
                }
            }
            if (ip == "0.0.0.0")
            {
                string IP = Request.Headers["Ip"];
                if (!string.IsNullOrEmpty(IP))
                    ip = IP;
            }
            return ip;
        }
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsNumber(String str) 
        {
            if (str.IndexOf("-") == 0)
            {
                str = str.Substring(1,str.Length-1);
            }

            if (str.Trim() != "")
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!Char.IsNumber(str, i))
                        return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断是否是小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsDouble(String str)
        {
            string stri = str.Replace(".", "");
            if (str.Length - stri.Length > 1) //判断被替换了几次，超过1次以上返回false
            {
                return false;
            }
            if (str.LastIndexOf(".") == (str.Length - 1)) //判断点号是否在最后一位
            {
                return false;
            }
            for (int i = 0; i < stri.Length; i++)
            {
                if (!Char.IsNumber(stri, i))
                    return false;
            }
            return true;
        }
        //附件目录地址
        /// <summary>
        /// 保存的根目录地址(后面添加下划线)
        /// </summary>
        public string SaveAnnexPath
        {
            get
            {
                object objAnnexPath = System.Configuration.ConfigurationManager.AppSettings["ConfigPath"];
                if (objAnnexPath == null)
                {
                    string FilePath = Server.MapPath("~/FileUploads");
                    return Datas.PublicCls.File.PathConfig.PathEnd(FilePath);
                }
                string KeyValue = Datas.PublicCls.ConfigManager.ReadKeyValue(objAnnexPath.ToString() + "Program.xml", "AnnexPath");
                if (System.IO.Path.IsPathRooted(KeyValue))
                    return Datas.PublicCls.File.PathConfig.PathEnd(KeyValue);
                return Datas.PublicCls.File.PathConfig.PathEnd(Server.MapPath("~/" + KeyValue));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrganId
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["OrganId"].ToString();
            }
        }
        /// <summary>
        /// 根据此值获取当前图片所属哪个地区的
        /// </summary>
        public string ImgOrgan
        {
            get
            {
                string KeyValue = "";
                object objFileId = System.Configuration.ConfigurationManager.AppSettings["ConfigPath"];
                if (objFileId != null)
                {
                    KeyValue = Datas.PublicCls.ConfigManager.ReadKeyValue(objFileId.ToString() + "Program.xml", "ImgOrgan");
                }
                return KeyValue;
            }
        }
        public string FileID
        {
            get
            {
                string KeyValue = "";
                object objFileId = System.Configuration.ConfigurationManager.AppSettings["ConfigPath"];
                if (objFileId != null)
                {
                    KeyValue = Datas.PublicCls.ConfigManager.ReadKeyValue(objFileId.ToString() + "Program.xml", "FileID");
                }
                return KeyValue;
            }
        }

        /// <summary>
        /// 结束页面执行
        /// </summary>
        /// <param name="Info"></param>
        public void End(string Info) {
            HttpContext.Current.Response.Write(Info);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 结束页面执行
        /// </summary>
        /// <param name="Info"></param>
        public void End() {
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 触摸屏调用/Egh/IWeb/IGscInfo.asmx字符串
        /// </summary>
        public string UserToken
        {
            get
            {
                return "34E9B9EE-3194-4027-A0BD-5C28B070E4F1-26088B0C-3900-4B2E-9217-FE7B6B3CF9E5";
            }
        }
        /// <summary>
        /// XML转换DATATABLE
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public DataTable ConvertXmlToDataTable(string xml)
        {
            System.Xml.XmlDocument XmlDoc = new System.Xml.XmlDocument();
            XmlDoc.LoadXml(xml);
            System.Xml.XmlElement xmlRoot = XmlDoc.DocumentElement;
            System.Xml.XmlNode xmlCells = xmlRoot.SelectSingleNode("Cells");
            DataTable dtData = new DataTable();
            foreach (System.Xml.XmlNode xnCell in xmlCells.ChildNodes)
            {
                DataColumn dcHeader = new DataColumn(xnCell.InnerText, typeof(string));
                dtData.Columns.Add(dcHeader);
            }
            System.Xml.XmlNode xnRows = xmlRoot.SelectSingleNode("Rows");
            foreach (System.Xml.XmlNode xnRow in xnRows.ChildNodes)
            {
                DataRow drNew = dtData.NewRow();
                foreach (System.Xml.XmlNode xnCell in xnRow.ChildNodes)
                {

                    drNew[xnCell.Attributes["FieldName"].Value] = xnCell.InnerText;

                }
                dtData.Rows.Add(drNew);
            }
            return dtData;
        }
        /// <summary>
        /// DataTable转换XML
        /// </summary>
        /// <param name="dtData"></param>
        /// <returns></returns>
        private string ConvertDataTableToXml(DataTable dtData)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration XmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(XmlDec);
            XmlElement xmlRoot = xmlDoc.CreateElement("Datas");
            xmlDoc.AppendChild(xmlRoot);
            //列
            XmlElement xmlCells = xmlDoc.CreateElement("Cells");
            xmlRoot.AppendChild(xmlCells);
            foreach (DataColumn dcHeader in dtData.Columns)
            {
                XmlElement xmlHeader = xmlDoc.CreateElement("Cell");
                xmlHeader.InnerText = dcHeader.ColumnName;
                xmlCells.AppendChild(xmlHeader);
            }
            //行
            XmlElement xmlRows = xmlDoc.CreateElement("Rows");
            xmlRoot.AppendChild(xmlRows);
            foreach (DataRow drData in dtData.Rows)
            {
                XmlElement xmlRow = xmlDoc.CreateElement("Row");
                xmlRows.AppendChild(xmlRow);
                for (int CellIndex = 0; CellIndex < dtData.Columns.Count; CellIndex++)
                {
                    XmlElement xmlCell = xmlDoc.CreateElement("Cell");
                    XmlAttribute xmlAttrFieldName = xmlDoc.CreateAttribute("FieldName");
                    xmlAttrFieldName.Value = dtData.Columns[CellIndex].ColumnName;
                    xmlCell.Attributes.Append(xmlAttrFieldName);
                    XmlCDataSection XmlCData = xmlDoc.CreateCDataSection(drData[CellIndex].ToString());
                    xmlCell.AppendChild(XmlCData);
                    xmlRow.AppendChild(xmlCell);
                }
            }
            return xmlDoc.OuterXml;
        }
        /// <summary>
        /// DataTable翻页功能
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页显示多少条数据</param>
        /// <returns>返回处理后的数据</returns>
        /// <summary>
        /// DataTable翻页功能
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页显示多少条数据</param>
        /// <returns>返回处理后的数据</returns>
        public DataTable GetDataTablePagination(DataTable dt, int PageIndex, int PageSize)
        {
            //如果不是有效参数 返回null 
            if (dt == null || dt.Rows.Count == 0 || PageSize <= 0 || PageIndex < 0)
            {
                return null;
            }
            //如果总数小于分页数直接返回数据 
            if (dt.Rows.Count <= PageSize)
            {
                return dt;
            }
            int _totalCount = 0;
            _totalCount = dt.Rows.Count / PageSize;
            if (dt.Rows.Count % PageSize > 0)
            {
                _totalCount++;
            }
            PageIndex++;
            for (int i = 1; i < PageIndex; i++)
            {
                dt = RemoveDataTableRows(dt, 0, PageSize);
            }
            return GetDataTableRows(dt, 0, PageSize);
        }
        /// <summary> 
        /// 根据数据表 指定 行数的索引值 删除指定的行个数 
        /// </summary> 
        /// <param name="dt">要操作的数据表</param> 
        /// <param name="rowIndex">开始删除的行号(行索引值)</param> 
        /// <param name="num">删除行数</param> 
        /// <returns>返回处理后的数据表</returns> 
        public DataTable RemoveDataTableRows(DataTable dt, int rowIndex, int num)
        {
            if (dt == null || dt.Rows.Count == 0 || rowIndex < 0 || num < 0)
            {
                return dt;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == rowIndex)
                {
                    for (int j = 0; j < num; j++)
                    {
                        dt.Rows.RemoveAt(rowIndex);//.Rows[].Delete(); 
                    }
                    break;
                }
            }
            return dt;
        }
        /// <summary> 
        /// 根据数据表 指定 行数的索引值 获取指定的行个数数据 
        /// </summary> 
        /// <param name="dt">要操作的数据表</param> 
        /// <param name="rowIndex">开始获取数据的行号(行索引值)</param> 
        /// <param name="num">获取的行数</param> 
        /// <returns>返回处理后的数据表</returns> 
        public DataTable GetDataTableRows(DataTable dt, int rowIndex, int num)
        {
            if (dt == null || dt.Rows.Count == 0 || rowIndex < 0 || num < 0)
            {
                return dt;
            }
            DataTable dt1 = new DataTable();
            dt1 = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == rowIndex)
                {
                    for (int j = 0; j < num; j++)
                    {

                        if (i + j + 1 <= dt.Rows.Count)
                        {

                            dt1.Rows.Add(dt.Rows[rowIndex + j].ItemArray);

                        }

                    }

                    break;

                }
            }
            return dt1;
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name=”time”></param>
        /// <returns></returns>
        public int ConvertDateTimeInt()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(DateTime.Now - startTime).TotalSeconds;
        }
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  string ToBase64(string input)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  string FromBase64(string input)
        {
            byte[] bytes = Convert.FromBase64String(input);

            return System.Text.Encoding.Default.GetString(bytes);
        }
        /// <summary> 
        /// 在指定的字符串列表CnStr中检索符合拼音索引字符串 
        /// </summary> 
        /// <param name="CnStr">汉字字符串</param> 
        /// <returns>相对应的汉语拼音首字母串</returns> 
        public string GetSpellCode(string CnStr)
        {
            string strTemp = "";
            int iLen = CnStr.Length;
            int i = 0;

            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += GetCharSpellCode(CnStr.Substring(i, 1));
            }

            return strTemp;
        }
        /// <summary> 
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
        /// </summary> 
        /// <param name="CnChar">单个汉字</param> 
        /// <returns>单个大写字母</returns> 
        private string GetCharSpellCode(string CnChar)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回 
            if (ZW.Length == 1)
            {
                return CnChar.ToUpper();
            }
            else
            {
                // get the array of byte from the single char 
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }

            //expresstion 
            //table of the constant list 
            // 'A'; //45217..45252 
            // 'B'; //45253..45760 
            // 'C'; //45761..46317 
            // 'D'; //46318..46825 
            // 'E'; //46826..47009 
            // 'F'; //47010..47296 
            // 'G'; //47297..47613 

            // 'H'; //47614..48118 
            // 'J'; //48119..49061 
            // 'K'; //49062..49323 
            // 'L'; //49324..49895 
            // 'M'; //49896..50370 
            // 'N'; //50371..50613 
            // 'O'; //50614..50621 
            // 'P'; //50622..50905 
            // 'Q'; //50906..51386 

            // 'R'; //51387..51445 
            // 'S'; //51446..52217 
            // 'T'; //52218..52697 
            //没有U,V 
            // 'W'; //52698..52979 
            // 'X'; //52980..53640 
            // 'Y'; //53689..54480 
            // 'Z'; //54481..55289 

            // iCnChar match the constant 
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }

            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return ("?");
        }

        /// <summary>
        /// 获取配置文件的值
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string GetProgramVarValue(string Key)
        {
            object objAnnexPath = System.Configuration.ConfigurationManager.AppSettings["ConfigPath"];
            string KeyValue = Datas.PublicCls.ConfigManager.ReadKeyValue(objAnnexPath.ToString() + "Program.xml", Key);
            return KeyValue;
        }

        public string Numeral_CookOrganId
        {
            get
            {
                HttpCookie Cookie = HttpContext.Current.Request.Cookies["Numeral_CookOrganId"];
                if (Cookie != null)
                {
                    return Cookie.Value;
                }
                return string.Empty;
            }
        }
        public string Numeral_WindowCode
        {
            get
            {
                HttpCookie Cookie = HttpContext.Current.Request.Cookies["Numeral_WindowCode"];
                if (Cookie != null)
                {
                    return Cookie.Value;
                }
                return string.Empty;
            }
        }

        public string Memorization(DateTime time, string IDcard)
        {
            string[] initialV = {"!","@","#","$","%","^","&","*","-","+"};
            int[] take=new int[]{7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2};
            int value1 = int.Parse(time.ToString("yyyy")) + int.Parse(time.ToString("MM")) + int.Parse(time.ToString("dd")) + int.Parse(time.ToString("hh"))
                + int.Parse(time.ToString("mm")) + int.Parse(time.ToString("ss"));
            int value2 = 0;
            if (IDcard != ""&&IDcard.Length>17)
            {
                string str = IDcard.Substring(0, 17);
                if (IsNumber(str))
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        value2 = value2 + take[i] * int.Parse(str.Substring(i, 1));
                    }
                }
            }
            int value3 = value1 + value2;
            return initialV[value3 % 10];

        }
    }
}