<%
-- Copyright (c) 2014 Chimera Software, LLC
-- 
-- Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files 
-- (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, 
-- publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
-- subject to the following conditions:
-- 
-- The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
-- 
-- THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
-- MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
-- FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
-- WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 %>

using UnityEngine;

<%
FULL_NAME_CAPS = "_"..string.upper(this.namespace).."_"..string.upper(this.name).."_";
CAP_NAME = capitalizedString(this.name);
FULL_NAME_CAMEL = namespaceInitials(this.namespace)..capitalizedString(this.name);
%>
//
// Autogenerated by gaxb ( https://github.com/SmallPlanet/gaxb )
//

using System;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Security;
using TBSharpXML;

public partial class <%= FULL_NAME_CAMEL %> : <%= FULL_NAME_CAMEL %>Base {
	
	public <%= FULL_NAME_CAMEL %>()
	{<%
			didPrintAttr = false;
			for k,v in pairs(this.attributes) do
				if (v.default ~= nil) then
				
					if (didPrintAttr == false) then
						didPrintAttr = true;
						gaxb_print("\n\t\tstring attr;\n\n")
					end
					
					if (v.default == "UUID_REGISTER") then
						gaxb_print("\t\tattr = UUID.Generate ();\n")
					else
						gaxb_print('\t\tattr = "'..v.default..'";\n')
					end
					
					
					if (typeNameForItem(v)=="bool") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = bool.Parse(attr); } \n")
					elseif (typeNameForItem(v)=="string") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = attr; } \n")
					elseif (typeNameForItem(v)=="float") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = float.Parse(attr); } \n")
					elseif (typeNameForItem(v)=="short") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = short.Parse(attr); } \n")
					elseif (typeNameForItem(v)=="int") then
						if (isEnumForItem(v)) then
							gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = "..v.type.namespace.."."..v.type.name..".PUParse(attr); } \n")
						else
							gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = (int)float.Parse(attr); } \n")
						end
					elseif (typeNameForItem(v)=="long") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = long.Parse(attr); } \n")
					elseif (typeNameForItem(v)=="double") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = double.Parse(attr); } \n")
					elseif (typeNameForItem(v)=="char") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = char.Parse(attr); } \n")
					elseif (typeNameForItem(v)=="DateTime") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = DateTime.Parse(attr); } \n")
					elseif (typeNameForItem(v)=="byte[]") then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = Convert.FromBase64String(attr); } \n")
					elseif (isEnumForItem(v)) then
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = ("..typeForItem(v)..")Enum.Parse(typeof("..typeForItem(v).."), attr); } \n")
					else
						gaxb_print("\t\tif(attr != null) { "..cleanedName(v.name).." = new "..typeForItem(v).."().PUParse(attr); } \n")
					end
					
					
				end
			end
		%>
	}
	<%
	allAttributes = allAttributesForClass(this);
	allRequiredAttributes = mixedAttributesForClass(this);
	
	if(#allRequiredAttributes > 0) then %>
	
	public <%= FULL_NAME_CAMEL %>(<%
		gaxb_print("\n");
		for i,v in ipairs(allRequiredAttributes) do
			gaxb_print("\t\t\t"..typeForItem(v).." "..cleanedName(v.name));
			if(i ~= #allRequiredAttributes) then
				gaxb_print(",\n");
			end
		end%> ) : this()
	{
<%
		for i,v in ipairs(allRequiredAttributes) do
			gaxb_print("\t\tthis."..cleanedName(v.name).." = "..cleanedName(v.name)..";\n");
			if(i ~= #allRequiredAttributes) then gaxb_print("\n"); end
		end%>	}
<% end %>
	<%
	if(#allAttributes > 0 and #allAttributes ~= #allRequiredAttributes) then %>
	
	public <%= FULL_NAME_CAMEL %>(<%
		gaxb_print("\n");
		for i,v in ipairs(allAttributes) do
			gaxb_print("\t\t\t"..typeForItem(v).." "..cleanedName(v.name));
			if(i ~= #allAttributes) then
				gaxb_print(",\n");
			end
		end%> ) : this()
	{
<%
		for i,v in ipairs(allAttributes) do
			gaxb_print("\t\tthis."..cleanedName(v.name).." = "..cleanedName(v.name)..";\n");
			if(i ~= #allAttributes) then gaxb_print("\n"); end
		end%>	}
<% end %>

}


<%
SUPER_PLURAL_NAME = pluralName(superclassFieldNameForItem(this));
PLURAL_NAME = pluralName(this.name);
FULL_NAME_CAPS = "_"..string.upper(this.namespace).."_"..string.upper(this.name).."BASE".."_";
CAP_NAME = capitalizedString(this.name);
INTERFACE = "I"..namespaceInitials(this.namespace);
FULL_NAME_CAMEL = namespaceInitials(this.namespace)..capitalizedString(this.name).."Base";

FULL_NAME_CAMEL_NON_BASE = namespaceInitials(this.namespace)..capitalizedString(this.name);

if(hasSuperclass(this)) then
	NEW_KEYWORD = "override "
else
	NEW_KEYWORD = "virtual ";
end

%>

public class <%= FULL_NAME_CAMEL %> : <%= superclassForItem(this) %> {

<%  if (# this.attributes > 0) then %>
<% end %>

<%	if(hasSuperclass(this) == false) then
		gaxb_print("\tpublic object parent;\n")
		gaxb_print('\tpublic string xmlns = "'..this.namespaceURL..'";\n')
	end %>

	// XML Attributes
<%
for k,v in pairs(this.attributes) do
	gaxb_print("\tpublic "..nullableTypeForItem(v).." "..v.name..";\n")
end
if (this.mixedContent == true) then
	gaxb_print("\tpublic string mixedContent;\n\n");
end
%>

<%
if (# this.sequences > 0) then
	gaxb_print("\n\t// XML Sequences\n")
	for k,v in pairs(this.sequences) do
		if (v.name == "any") then
			gaxb_print("\tpublic List<object> children = new List<object>();\n")
		elseif(isPlural(v)) then
			gaxb_print("\tpublic List<object> "..pluralName(v.name).." = new List<object>();\n")
		else
			if(isObject(v)) then
				gaxb_print("\tpublic "..typeNameForItem(v).." "..v.name..";\n")
			else
				gaxb_print("\tpublic "..nullableTypeForItem(v).." "..v.name..";\n")
			end
		end
		gaxb_print("\t\n")
	end
end
%>

	public <%=NEW_KEYWORD%>void gaxb_unload()
	{
<%		if(hasSuperclass(this)) then
			gaxb_print("\t\tbase.gaxb_unload();\n")
		end
%>
	}
	
<%	if(hasSuperclass(this) == false) then
		gaxb_print("\tpublic void gaxb_addToParent()\n")
	else
		gaxb_print("\tpublic new void gaxb_addToParent()\n")
	end %>
	{
		if(parent != null)
		{
			FieldInfo parentField = parent.GetType().GetField("<%= CAP_NAME %>");
			List<object> parentChildren = null;
			
			if(parentField != null)
			{
				parentField.SetValue(parent, this);
			}
			else
			{
				parentField = parent.GetType().GetField("<%= PLURAL_NAME %>");
				
				if(parentField != null)
				{
					parentChildren = (List<object>)(parentField.GetValue(parent));
				}
				else
				{
					parentField = parent.GetType().GetField("<%= SUPER_PLURAL_NAME %>");
					if(parentField != null)
					{
						parentChildren = (List<object>)(parentField.GetValue(parent));
					}
				}
				if(parentChildren == null)
				{
					FieldInfo childrenField = parent.GetType().GetField("children");
					if(childrenField != null)
					{
						parentChildren = (List<object>)childrenField.GetValue(parent);
					}
				}
				if(parentChildren != null)
				{
					parentChildren.Add(this);
				}
				
			}
		}
	}

	private string unescape(string s) {
		if (string.IsNullOrEmpty(s)) return s;

		string returnString = s;
		returnString = returnString.Replace("&apos;", "'");
		returnString = returnString.Replace("&quot;", "\\\"");
		returnString = returnString.Replace("&gt;", ">");
		returnString = returnString.Replace("&lt;", "<");
		returnString = returnString.Replace("&amp;", "&");
		return returnString;
	}

	public <%=NEW_KEYWORD%>void gaxb_load(TBXMLElement element, object _parent, Hashtable args)
	{
<%		if(hasSuperclass(this)) then
			gaxb_print("\t\tbase.gaxb_load(element, _parent, args);\n")
		end
%>
		if(element == null && _parent == null)
			return;
		
		parent = _parent;
		
		if(this.GetType() == typeof( <%= FULL_NAME_CAMEL_NON_BASE %> ))
		{
			gaxb_addToParent();
		}
		
		//xmlns = element.GetAttribute("xmlns");
		
<%
		if (# this.attributes > 0) then
			gaxb_print("\n\t\tstring attr;\n")
		end
		for k,v in pairs(this.attributes) do
			gaxb_print("\t\tattr = element.GetAttribute(\""..v.originalName.."\");\n")
			
			gaxb_print('\t\tif(attr != null) { attr = PlanetUnityOverride.processString(_parent, attr); }\n');
			
			if (v.default ~= nil) then
				if (v.default == "UUID_REGISTER") then
					gaxb_print("\t\tif(attr == null) { attr = UUID.Generate (); }\n")
				else
					gaxb_print("\t\tif(attr == null) { attr = \""..v.default.."\"; }\n")
				end
			end
			
			if (typeNameForItem(v)=="bool") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = bool.Parse(attr); } \n")
			elseif (typeNameForItem(v)=="string") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = unescape(attr); } \n")
			elseif (typeNameForItem(v)=="float") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = float.Parse(attr); } \n")
			elseif (typeNameForItem(v)=="short") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = short.Parse(attr); } \n")
			elseif (typeNameForItem(v)=="int") then
				if (isEnumForItem(v)) then
					gaxb_print("\t\tif(attr != null) { "..v.name.." = "..v.type.namespace.."."..v.type.name..".PUParse(attr); } \n")
				else
					gaxb_print("\t\tif(attr != null) { "..v.name.." = (int)float.Parse(attr); } \n")
				end
			elseif (typeNameForItem(v)=="long") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = long.Parse(attr); } \n")
			elseif (typeNameForItem(v)=="double") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = double.Parse(attr); } \n")
			elseif (typeNameForItem(v)=="char") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = char.Parse(attr); } \n")
			elseif (typeNameForItem(v)=="DateTime") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = DateTime.Parse(attr); } \n")
			elseif (typeNameForItem(v)=="byte[]") then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = Convert.FromBase64String(attr); } \n")
			elseif (isEnumForItem(v)) then
				gaxb_print("\t\tif(attr != null) { "..v.name.." = ("..typeForItem(v)..")Enum.Parse(typeof("..typeForItem(v).."), attr); } \n")
			else
				gaxb_print("\t\tif(attr != null) { "..v.name.." = new "..typeForItem(v).."().PUParse(attr); } \n")
			end
			
			gaxb_print("\t\t\n")
		end
		%>
	}
	
	
	
	
	
	
	
	public <%=NEW_KEYWORD%>void gaxb_appendXMLAttributes(StringBuilder sb)
	{
<%		if(hasSuperclass(this)) then
			gaxb_print("\t\tbase.gaxb_appendXMLAttributes(sb);\n")
		end %>
<%
		for k,v in pairs(this.attributes) do
			if (typeNameForItem(v)=="bool") then
				gaxb_print('\t\t sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'.ToString().ToLower()); \n')
			elseif (typeNameForItem(v)=="float") then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'.Value.ToString ("0.##")); }\n')
			elseif (typeNameForItem(v)=="short") then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'); }\n')
			elseif (typeNameForItem(v)=="int") then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'); }\n')
			elseif (typeNameForItem(v)=="long") then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'); }\n')
			elseif (typeNameForItem(v)=="double") then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'.Value.ToString ("0.##")); }\n')
			elseif (typeNameForItem(v)=="char") then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'); }\n')
			elseif (typeNameForItem(v)=="DateTime") then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'); }\n')
			elseif (typeNameForItem(v)=="byte[]") then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", Convert.ToBase64String('..v.name..')); }\n')
			elseif (isEnumForItem(v)) then
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", (int)'..v.name..'); }\n')
			elseif (isObject(v)) then
				if (string.sub(nullableTypeForItem(v),-1) == "?") then
					gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'.Value.PUToString()); }\n')
				else
					gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", '..v.name..'.PUToString()); }\n')
				end				
			else
				gaxb_print('\t\tif('..v.name..' != null) { sb.AppendFormat (" {0}=\\"{1}\\"", "'..v.name..'", SecurityElement.Escape ('..v.name..')); }\n')
			end
		end %>
	}
	
	public <%=NEW_KEYWORD%>void gaxb_appendXMLSequences(StringBuilder sb)
	{
<%		if(hasSuperclass(this)) then
			gaxb_print("\t\tbase.gaxb_appendXMLSequences(sb);\n")
		end %>
<%
		if (# this.sequences > 0) then
			gaxb_print('\t\tMethodInfo mInfo;');
			for k,v in pairs(this.sequences) do
				if (v.name == "any") then
					gaxb_print('\t\tfor(int i = 0; i < children.Count; i++) { object o = children[i]; mInfo = o.GetType().GetMethod("gaxb_appendXML"); if(mInfo != null) { mInfo.Invoke (o, new[] { sb }); } else { sb.AppendFormat ("<{0}>{1}</{0}>", "'..v.name..'", o); } }\n');
				elseif(isPlural(v)) then
					gaxb_print('\t\tfor(int i = 0; i < '..pluralName(v.name)..'.Count; i++) { object o = '..pluralName(v.name)..'[i]; mInfo = o.GetType().GetMethod("gaxb_appendXML"); if(mInfo != null) { mInfo.Invoke (o, new[] { sb }); } else { sb.AppendFormat ("<{0}>{1}</{0}>", "'..v.name..'", o); } }\n');
				else
					gaxb_print('\t\tif('..v.name..' != null) {\n');
					gaxb_print('\t\t\tmInfo = '..v.name..'.GetType().GetMethod("gaxb_appendXML"); if(mInfo != null) { mInfo.Invoke ('..v.name..', new[] { sb }); } else { sb.AppendFormat ("<{0}>{1}</{0}>", "'..v.name..'", '..v.name..'); } \n');
					gaxb_print('\t\t}\n');
				end
				gaxb_print("\t\n")
			end
		end
%>
	}
	
	public <%=NEW_KEYWORD%>void gaxb_appendXML(StringBuilder sb)
	{
		if(sb.Length == 0)
		{
			sb.AppendFormat ("<?xml version=\\"1.0\\" encoding=\\"UTF-8\\"?>");
		}
		
		sb.AppendFormat ("<{0}", "<%=this.name%>");
		
		if(xmlns != null) {
			if(parent == null) {
				sb.AppendFormat (" {0}=\\"{1}\\"", "xmlns", xmlns);
			}else{
				FieldInfo parentField = parent.GetType().GetField("xmlns");
				if(parentField != null && xmlns.Equals(parentField.GetValue(parent)) == false)
				{
					sb.AppendFormat (" {0}=\\"{1}\\"", "xmlns", xmlns);
				}
			}
		}
		
		gaxb_appendXMLAttributes(sb);
		
		
		StringBuilder seq = new StringBuilder();
		seq.AppendFormat(" ");
		gaxb_appendXMLSequences(seq);
		
		if(seq.Length == 1)
		{
			sb.AppendFormat (" />");
		}
		else
		{
<%			gaxb_print('\t\t\tsb.AppendFormat (">{0}</{1}>", seq.ToString(), "'..this.name..'");') %>
		}
	}
}
