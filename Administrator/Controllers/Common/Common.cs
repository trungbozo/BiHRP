using Newtonsoft.Json.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Model;
using Model.View;

namespace Administrator.Controllers.Common
{
    public class Common
    {
        private string webApiAddress = "http://localhost:18517/bitecco/";
        private string nameEntity = "Model";
        private string nameSpace = "Model";
        public IEnumerable<JObject> getListWebAPI(string ApiName)
        {
            try
            {
                IEnumerable<JObject> jList = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(webApiAddress);
                    var responseTask = client.GetAsync(ApiName);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IEnumerable<JObject>>();
                        readTask.Wait();
                        jList = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        jList = Enumerable.Empty<JObject>();
                    }
                }
                return jList;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public Object getListWebAPI(string ApiName, string modelName)
        {
            try
            {
                JObject jObject = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(webApiAddress);
                    var responseTask = client.GetAsync(ApiName);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<JObject>();
                        readTask.Wait();
                        jObject = readTask.Result;
                    }
                }
                Assembly assembly = Assembly.Load(nameEntity);
                Object obj = assembly.CreateInstance(nameSpace + "." + modelName);
                Type type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    var value = jObject[property.Name];
                    SetPropertyValue(obj, property.Name, value);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool postObjectWebAPI(JObject collection, string ApiName, string modelName)
        {
            try
            {
                // TODO: Add insert logic here
                Assembly assembly = Assembly.Load(nameEntity);
                Object obj = assembly.CreateInstance(nameSpace + "." + modelName);
                Type type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    var value = collection[property.Name];
                    SetPropertyValue(obj, property.Name, value);
                }
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(webApiAddress);
                    HttpContent content = new StringContent(obj.ToString(), Encoding.UTF8, "application/json");
                    var response = client.PostAsJsonAsync(ApiName, obj).Result;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool putObjectWebAPI(JObject collection, string ApiName, string modelName)
        {
            try
            {
                // TODO: Add insert logic here
                Assembly assembly = Assembly.Load(nameEntity);
                Object obj = assembly.CreateInstance(nameSpace + "." + modelName);
                Type type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    var value = collection[property.Name];
                    SetPropertyValue(obj, property.Name, value);
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(webApiAddress);
                    HttpContent content = new StringContent(obj.ToString(), Encoding.UTF8, "application/json");
                    var response = client.PutAsJsonAsync(ApiName, obj).Result;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool deleteObjectWebAPI(string ApiName)
        {
            try
            {
                //// TODO: Add insert logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(webApiAddress);
                    var response = client.DeleteAsync(ApiName).Result;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> getComboWebAPI(string ApiName,string text,string value)
        {
            try
            {
                IEnumerable<JObject> jList = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(webApiAddress);
                    var responseTask = client.GetAsync(ApiName);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IEnumerable<JObject>>();
                        readTask.Wait();
                        jList = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        jList = Enumerable.Empty<JObject>();
                    }
                }
                //Creating generic list
                List<SelectListItem> ObjList = new List<SelectListItem>();
                foreach (var item in jList)
                {
                    SelectListItem ObjListItem = new SelectListItem { Text = item[text].ToString(), Value = item[value].ToString() };
                    ObjList.Add(ObjListItem);
                };
                return ObjList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SetPropertyValue(object obj, string propertyName, object propertyValue)
        {
            try
            {
                if (obj == null || string.IsNullOrWhiteSpace(propertyName))
                {
                    return;
                }

                Type objectType = obj.GetType();

                PropertyInfo propertyDetail = objectType.GetProperty(propertyName);


                if (propertyDetail != null && propertyDetail.CanWrite)
                {
                    Type propertyType = propertyDetail.PropertyType;

                    Type dataType = propertyType;

                    // Check for nullable types
                    if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        // Check for null or empty string value.
                        if (propertyValue == null || string.IsNullOrWhiteSpace(propertyValue.ToString()))
                        {
                            propertyDetail.SetValue(obj, null);
                            return;
                        }
                        else
                        {
                            dataType = propertyType.GetGenericArguments()[0];
                        }
                    }

                    Type t = Nullable.GetUnderlyingType(propertyDetail.PropertyType) ?? propertyDetail.PropertyType;
                    if(t.Name == "ICollection`1")
                    {
                        "".ToString();
                    }
                    else
                    {
                        try
                        {
                            object safeValue = (propertyValue == null || "".Equals(propertyValue)) ? null : Convert.ChangeType(propertyValue, t);
                            propertyDetail.SetValue(obj, safeValue, null);
                        }catch(Exception e)
                        {
                            e.ToString();
                            propertyDetail.SetValue(obj, null, null);
                        }
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public string getXmlTree(IEnumerable<JObject> Parrent, string DisplayText, string ValueText, string ValueChild)
        {
            try
            {
                string xmlTree = "<tree id='0'>";
                foreach (JObject itemTree in Parrent)
                {
                    xmlTree += "<item text='" + itemTree[DisplayText].ToString() + "' id='" + itemTree[ValueText].ToString() + "' open='1'>";
                    xmlTree += getChildTree((JArray)itemTree[ValueChild], DisplayText, ValueText, ValueChild);
                    xmlTree += "</item>";
                }
                xmlTree += "</tree>";
                return xmlTree;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private string getChildTree(JArray Parrent, string DisplayText, string ValueText, string ValueChild)
        {
            string xmlTree = "";
            foreach (JObject itemTree in Parrent)
            {
                xmlTree += "<item text='" + itemTree[DisplayText].ToString() + "' id='" + itemTree[ValueText].ToString() + "' open='1'>";
                xmlTree += getChildTree((JArray)itemTree[ValueChild], DisplayText, ValueText, ValueChild);
                xmlTree += "</item>";
            }
            return xmlTree;
        }
        public List<FormData> getDataForm(IEnumerable<JObject> Parrent)
        {
            try
            {
                List<FormData> strData = new List<FormData>();
                foreach (JObject itemData in Parrent)
                {
                    FormData strItem = new FormData();
                    strItem.NameControl = itemData["NameControl"].ToString();
                    strItem.ValueControl = itemData["ValueControl"].ToString();
                    strData.Add(strItem);
                }
                return strData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getXmlForm(IEnumerable<JObject> formControl, SYS_Form formConfig)
        {
            try
            {
                string xmlForm = "<items>";
                xmlForm += "<item type='settings' position='label-left' labelWidth='" + formConfig.LabelWidth + "' inputWidth='" + formConfig.InputWidth + "'/>";
                foreach (var item in formControl)
                {
                    switch (item["TypeControl"].ToString())
                    {
                        case "fieldset":
                            xmlForm += "<item type='fieldset' name='" + formConfig.NameForm + "' label='" + formConfig.NameForm + "' inputWidth='" + item["WidthControl"].ToString() + "'>";
                            xmlForm += getChildForm((JObject)item);
                            xmlForm += "</item>";
                            break;
                        default:
                            break;
                    }
                }
                xmlForm += "</items>";
                return xmlForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string getChildForm(JObject Parrent)
        {
            string xmlForm = "";
            JArray itemList = (JArray)Parrent["SYS_Control1"];
            JArray sortedList = new JArray(itemList.OrderBy(obj => (string)obj["OrderBy"]));
            foreach (var itemChild in sortedList)
            {
                switch (itemChild["TypeControl"].ToString())
                {
                    case "key":
                        xmlForm += "<item type='hidden' name='" + itemChild["NameControl"].ToString() + "' disabled='" + itemChild["ValueDisable"].ToString() + "'/>";
                        xmlForm += "<item type='hidden' name='hdTypeControl_" + itemChild["NameControl"].ToString() + "' value='key'/>";
                        break;
                    case "block":
                        xmlForm += "<item type='block' inputWidth='" + itemChild["WidthControl"].ToString() + "' blockOffset='0' >";
                        xmlForm += getChildForm((JObject)itemChild);
                        xmlForm += "</item>";
                        break;
                    case "newcolumn":
                        xmlForm += "<item type='newcolumn' offset='20'/>";
                        break;
                    case "combo":
                        xmlForm += "<item type='combo' name='" + itemChild["NameControl"].ToString() + "' label='" + itemChild["LabelControl"].ToString() + "' disabled='" + itemChild["ValueDisable"].ToString() + "' required='" + itemChild["ValueRequired"].ToString() + "' validate='" + itemChild["ValueValidate"].ToString() + "' inputWidth='" + itemChild["WidthControl"].ToString() + "'>";
                        foreach (JObject itemCombo in (IEnumerable<JObject>)getListWebAPI(itemChild["ApiName"].ToString()))
                        {
                            xmlForm += "<option text='" + itemCombo[itemChild["DisplayText"].ToString()].ToString() + "' value='" + itemCombo[itemChild["ValueText"].ToString()].ToString() + "'/>";
                        }
                        xmlForm += "</item>";
                        break;
                    case "tree":
                        xmlForm += "<item type='container' name='" + itemChild["NameControl"].ToString() + "' label='" + itemChild["LabelControl"].ToString() + "' disabled='" + itemChild["ValueDisable"].ToString() + "' inputWidth='" + itemChild["WidthControl"].ToString() + "' inputHeight='" + itemChild["HeightControl"].ToString() + "'>";
                        xmlForm += "</item>";
                        xmlForm += "<item type='hidden' name='hdApiName_" + itemChild["NameControl"].ToString() + "' value='" + itemChild["ApiName"].ToString() + "'/>";
                        xmlForm += "<item type='hidden' name='hdDisplayText_" + itemChild["NameControl"].ToString() + "' value='" + itemChild["DisplayText"].ToString() + "'/>";
                        xmlForm += "<item type='hidden' name='hdValueText_" + itemChild["NameControl"].ToString() + "' value='" + itemChild["ValueText"].ToString() + "'/>";
                        xmlForm += "<item type='hidden' name='hdValueChild_" + itemChild["NameControl"].ToString() + "' value='" + itemChild["ValueChild"].ToString() + "'/>";
                        xmlForm += "<item type='hidden' name='hdValue_" + itemChild["NameControl"].ToString() + "'/>";
                        xmlForm += "<item type='hidden' name='hdTypeControl_" + itemChild["NameControl"].ToString() + "' value='tree'/>";
                        break;
                    case "calendar":
                        xmlForm += "<item type='calendar' name='" + itemChild["NameControl"].ToString() + "' label='" + itemChild["LabelControl"].ToString() + "' disabled='" + itemChild["ValueDisable"].ToString() + "' required='" + itemChild["ValueRequired"].ToString() + "' dateFormat='" + itemChild["ValueDateFormat"].ToString() + "' serverDateFormat='" + itemChild["ValueServerDateFormat"].ToString() + "' calendarPosition='right' inputWidth='" + itemChild["WidthControl"].ToString() + "'/>";
                        break;
                    case "checkbox":
                        xmlForm += "<item type='" + itemChild["TypeControl"].ToString() + "' name='" + itemChild["NameControl"].ToString() + "' label='" + itemChild["LabelControl"].ToString() + "' disabled='" + itemChild["ValueDisable"].ToString() + "' required='" + itemChild["ValueRequired"].ToString() + "' checked='false'/>";
                        break;
                    default:
                        xmlForm += "<item type='" + itemChild["TypeControl"].ToString() + "' name='" + itemChild["NameControl"].ToString() + "' label='" + itemChild["LabelControl"].ToString() + "' disabled='" + itemChild["ValueDisable"].ToString() + "' required='" + itemChild["ValueRequired"].ToString() + "' validate='" + itemChild["ValueValidate"].ToString() + "' maxLength='" + itemChild["ValueMaxLength"].ToString() + "' numberFormat='" + itemChild["ValueNumberFormat"].ToString() + "' inputWidth='" + itemChild["WidthControl"].ToString() + "'/>";
                        break;
                }
            }
            return xmlForm;
        }
        public string getXmlToolbar(IEnumerable<JObject> formToolbar)
        {
            try
            {
                string xmlToolbar = "<toolbar>";
                foreach (var item in formToolbar)
                {
                    switch (item["ToolbarType"].ToString())
                    {
                        case "separator":
                            xmlToolbar += "<item type='separator'	id='" + item["ID_SYS_Toolbar"].ToString() + "'/>";
                            break;
                        case "buttonSelect":
                            xmlToolbar += "<item id='" + item["ID_SYS_Toolbar"].ToString() + "' type='" + item["ToolbarType"].ToString() + "' img='" + item["ToolbarImage"].ToString() + "' imgdis='" + item["ToolbarDisImage"].ToString() + "' text='" + item["ToolbarText"].ToString() + "'>";
                            xmlToolbar += getChildToolbar(item);
                            xmlToolbar += "</item>";
                            break;
                        default:
                            if ((bool)item["DisableItem"])
                            {
                                xmlToolbar += "<item id='" + item["ID_SYS_Toolbar"].ToString() + "' type='" + item["ToolbarType"].ToString() + "' img='" + item["ToolbarImage"].ToString() + "' imgdis='" + item["ToolbarDisImage"].ToString() + "' text='" + item["ToolbarText"].ToString() + "'>";
                            }
                            else
                            {
                                xmlToolbar += "<item id='" + item["ID_SYS_Toolbar"].ToString() + "' type='" + item["ToolbarType"].ToString() + "' img='" + item["ToolbarImage"].ToString() + "' imgdis='" + item["ToolbarDisImage"].ToString() + "' text='" + item["ToolbarText"].ToString() + "' enabled='false'>";
                            }
                            xmlToolbar += "</item>";
                            break;
                    }
                }
                xmlToolbar += "</toolbar>";
                return xmlToolbar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string getChildToolbar(JObject Parrent)
        {
            try
            {
                string xmlToolbar="";
                JArray itemList = (JArray)Parrent["SYS_Toolbar1"];
                JArray sortedList = new JArray(itemList.OrderBy(obj => (string)obj["OrderBy"]));
                foreach (JObject item in sortedList)
                {

                    switch (item["ToolbarType"].ToString())
                    {
                        case "separator":
                            xmlToolbar += "<item type='separator'	id='" + item["ID_SYS_Toolbar"].ToString() + "'/>";
                            break;
                        case "buttonSelect":
                            xmlToolbar += "<item id='" + item["ID_SYS_Toolbar"].ToString() + "' type='" + item["ToolbarType"].ToString() + "' img='" + item["ToolbarImage"].ToString() + "' imgdis='" + item["ToolbarDisImage"].ToString() + "' text='" + item["ToolbarText"].ToString() + "'>";
                            xmlToolbar += getChildToolbar(item);
                            xmlToolbar += "</item>";
                            break;
                        default:
                            if ((bool)item["DisableItem"])
                            {
                                xmlToolbar += "<item id='" + item["ID_SYS_Toolbar"].ToString() + "' type='" + item["ToolbarType"].ToString() + "' img='" + item["ToolbarImage"].ToString() + "' imgdis='" + item["ToolbarDisImage"].ToString() + "' text='" + item["ToolbarText"].ToString() + "'>";
                            }
                            else
                            {
                                xmlToolbar += "<item id='" + item["ID_SYS_Toolbar"].ToString() + "' type='" + item["ToolbarType"].ToString() + "' img='" + item["ToolbarImage"].ToString() + "' imgdis='" + item["ToolbarDisImage"].ToString() + "' text='" + item["ToolbarText"].ToString() + "' enabled='false'>";
                            }
                            xmlToolbar += "</item>";
                            break;
                    }
                }
                return xmlToolbar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getToolbarAction(IEnumerable<JObject> formToolbar, int idAction)
        {
            try
            {
                foreach (var item in formToolbar)
                {
                    if(idAction.Equals((int)item["ID_SYS_Toolbar"]))
                    {
                        return item["ToolbarAction"].ToString();
                    }
                    string sAction = getToolbarActionChild((JObject)item,idAction);
                    if (!"".Equals(sAction))
                        return sAction;

                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string getToolbarActionChild(JObject formToolbar, int idAction)
        {
            try
            {
                foreach (var item in (JArray)formToolbar["SYS_Toolbar1"])
                {
                    if (idAction.Equals((int)item["ID_SYS_Toolbar"]))
                    {
                        return item["ToolbarAction"].ToString();
                    }
                    string sAction = getToolbarActionChild((JObject)item, idAction);
                    if (!"".Equals(sAction))
                        return sAction;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HSSFWorkbook read_xls(string file_name, IEnumerable<JObject> listData, string modelName)
        {
            Assembly assembly = Assembly.Load(nameEntity);
            Object obj = assembly.CreateInstance(nameSpace + "." + modelName);
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            int numberColumn = properties.Length;
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Template/xls/" + file_name), FileMode.Open);
            HSSFWorkbook wb = new HSSFWorkbook(fs);
            ISheet sheet = wb.GetSheetAt(0);
            int rowIndex = 2;
            var rowTitle = sheet.CreateRow(rowIndex);
            rowTitle.CreateCell(0);
            CellRangeAddress cellMerge = new CellRangeAddress(rowIndex, rowIndex, 0, numberColumn);
            sheet.AddMergedRegion(cellMerge);
            rowTitle.GetCell(0).SetCellValue("EXPORT XLS USING NPOI");
            rowIndex++;
            var rowHeader = sheet.CreateRow(rowIndex);
            int colIndex = 0;
            foreach (PropertyInfo property in properties)
            {
                rowHeader.CreateCell(colIndex).SetCellValue(property.Name);
                colIndex++;
            }
            foreach (JObject item in listData)
            {
                rowIndex++;
                var rowData = sheet.CreateRow(rowIndex);
                colIndex = 0;
                foreach (PropertyInfo property in properties)
                {
                    rowData.CreateCell(colIndex).SetCellValue(item[property.Name].ToString());
                    colIndex++;
                }
            }
            return wb;
        }
        public XSSFWorkbook read_xlsx(string file_name, IEnumerable<JObject> listData, string modelName)
        {
            Assembly assembly = Assembly.Load(nameEntity);
            Object obj = assembly.CreateInstance(nameSpace + "." + modelName);
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            int numberColumn = properties.Length;
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Template/xlsx/" + file_name), FileMode.Open);
            XSSFWorkbook wb = new XSSFWorkbook(fs);
            ISheet sheet = wb.GetSheetAt(0);
            int rowIndex = 2;
            var rowTitle = sheet.CreateRow(rowIndex);
            rowTitle.CreateCell(0);
            CellRangeAddress cellMerge = new CellRangeAddress(rowIndex, rowIndex, 0, numberColumn);
            sheet.AddMergedRegion(cellMerge);
            rowTitle.GetCell(0).SetCellValue("EXPORT XLSX USING NPOI");
            rowIndex++;
            var rowHeader = sheet.CreateRow(rowIndex);
            int colIndex = 0;
            foreach (PropertyInfo property in properties)
            {
                rowHeader.CreateCell(colIndex).SetCellValue(property.Name);
                colIndex++;
            }
            foreach (JObject item in listData)
            {
                rowIndex++;
                var rowData = sheet.CreateRow(rowIndex);
                colIndex = 0;
                foreach (PropertyInfo property in properties)
                {
                    rowData.CreateCell(colIndex).SetCellValue(item[property.Name].ToString());
                    colIndex++;
                }
            }
            return wb;
        }
        public string LoadItemXML(string node, string item, XmlDocument xmldoc)
        {
            try
            {
                XmlNode root = xmldoc.DocumentElement;
                XmlNodeList nodeList = root.SelectNodes(node);
                if(nodeList.Count > 0)
                {
                    string text = nodeList.Item(0)[item].InnerText;
                    return text;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}