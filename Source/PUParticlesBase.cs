

using UnityEngine;


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

public partial class PUParticles : PUParticlesBase {
	
	public PUParticles()
	{
		string attr;

		attr = "true";
		if(attr != null) { limitToInside = bool.Parse(attr); } 
		attr = "SystemScaled";
		if(attr != null) { emitMode = (PlanetUnity2.ParticleEmitMode)Enum.Parse(typeof(PlanetUnity2.ParticleEmitMode), attr); } 
		attr = "true";
		if(attr != null) { adjustToFPS = bool.Parse(attr); } 

	}
	
	
	public PUParticles(
			string systemName,
			bool limitToInside,
			PlanetUnity2.ParticleEmitMode emitMode,
			bool adjustToFPS,
			Vector2 customScale,
			string imageMaskPath ) : this()
	{
		this.systemName = systemName;

		this.limitToInside = limitToInside;

		this.emitMode = emitMode;

		this.adjustToFPS = adjustToFPS;

		this.customScale = customScale;

		this.imageMaskPath = imageMaskPath;
	}

	
	
	public PUParticles(
			string systemName,
			bool limitToInside,
			PlanetUnity2.ParticleEmitMode emitMode,
			bool adjustToFPS,
			Vector2 customScale,
			string imageMaskPath,
			Vector4 bounds,
			Vector3 position,
			Vector2 size,
			Vector3 rotation,
			Vector3 scale,
			Vector2 pivot,
			string anchor,
			bool active,
			bool mask,
			bool showMaskGraphic,
			Vector4 maskInset,
			bool outline,
			float lastY,
			float lastX,
			string shader,
			bool ignoreMouse,
			string components,
			string title,
			string tag,
			string tag1,
			string tag2,
			string tag3,
			string tag4,
			string tag5,
			string tag6 ) : this()
	{
		this.systemName = systemName;

		this.limitToInside = limitToInside;

		this.emitMode = emitMode;

		this.adjustToFPS = adjustToFPS;

		this.customScale = customScale;

		this.imageMaskPath = imageMaskPath;

		this.bounds = bounds;

		this.position = position;

		this.size = size;

		this.rotation = rotation;

		this.scale = scale;

		this.pivot = pivot;

		this.anchor = anchor;

		this.active = active;

		this.mask = mask;

		this.showMaskGraphic = showMaskGraphic;

		this.maskInset = maskInset;

		this.outline = outline;

		this.lastY = lastY;

		this.lastX = lastX;

		this.shader = shader;

		this.ignoreMouse = ignoreMouse;

		this.components = components;

		this.title = title;

		this.tag = tag;

		this.tag1 = tag1;

		this.tag2 = tag2;

		this.tag3 = tag3;

		this.tag4 = tag4;

		this.tag5 = tag5;

		this.tag6 = tag6;
	}


}




public class PUParticlesBase : PUCustomGeometry {






	// XML Attributes
	public string systemName;
	public bool limitToInside;
	public PlanetUnity2.ParticleEmitMode? emitMode;
	public bool adjustToFPS;
	public Vector2? customScale;
	public string imageMaskPath;




	public override void gaxb_unload()
	{
		base.gaxb_unload();

	}
	
	public new void gaxb_addToParent()

	{
		if(parent != null)
		{
			FieldInfo parentField = parent.GetType().GetField("Particles");
			List<object> parentChildren = null;
			
			if(parentField != null)
			{
				parentField.SetValue(parent, this);
			}
			else
			{
				parentField = parent.GetType().GetField("Particless");
				
				if(parentField != null)
				{
					parentChildren = (List<object>)(parentField.GetValue(parent));
				}
				else
				{
					parentField = parent.GetType().GetField("CustomGeometrys");
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
		returnString = returnString.Replace("&quot;", "\"");
		returnString = returnString.Replace("&gt;", ">");
		returnString = returnString.Replace("&lt;", "<");
		returnString = returnString.Replace("&amp;", "&");
		return returnString;
	}

	public override void gaxb_load(XmlReader reader, object _parent, Hashtable args)
	{
		base.gaxb_load(reader, _parent, args);

		if(reader == null && _parent == null)
			return;
		
		parent = _parent;
		
		if(this.GetType() == typeof( PUParticles ))
		{
			gaxb_addToParent();
		}
		
		//xmlns = reader.GetAttribute("xmlns");
		

		string attr;
		attr = reader.GetAttribute("systemName");
		if(attr != null) { attr = PlanetUnityOverride.processString(_parent, attr); }
		if(attr != null) { systemName = unescape(attr); } 
		
		attr = reader.GetAttribute("limitToInside");
		if(attr != null) { attr = PlanetUnityOverride.processString(_parent, attr); }
		if(attr == null) { attr = "true"; }
		if(attr != null) { limitToInside = bool.Parse(attr); } 
		
		attr = reader.GetAttribute("emitMode");
		if(attr != null) { attr = PlanetUnityOverride.processString(_parent, attr); }
		if(attr == null) { attr = "SystemScaled"; }
		if(attr != null) { emitMode = (PlanetUnity2.ParticleEmitMode)Enum.Parse(typeof(PlanetUnity2.ParticleEmitMode), attr); } 
		
		attr = reader.GetAttribute("adjustToFPS");
		if(attr != null) { attr = PlanetUnityOverride.processString(_parent, attr); }
		if(attr == null) { attr = "true"; }
		if(attr != null) { adjustToFPS = bool.Parse(attr); } 
		
		attr = reader.GetAttribute("customScale");
		if(attr != null) { attr = PlanetUnityOverride.processString(_parent, attr); }
		if(attr != null) { customScale = new Vector2().PUParse(attr); } 
		
		attr = reader.GetAttribute("imageMaskPath");
		if(attr != null) { attr = PlanetUnityOverride.processString(_parent, attr); }
		if(attr != null) { imageMaskPath = unescape(attr); } 
		

	}
	
	
	
	
	
	
	
	public override void gaxb_appendXMLAttributes(StringBuilder sb)
	{
		base.gaxb_appendXMLAttributes(sb);

		if(systemName != null) { sb.AppendFormat (" {0}=\"{1}\"", "systemName", SecurityElement.Escape (systemName)); }
		 sb.AppendFormat (" {0}=\"{1}\"", "limitToInside", limitToInside.ToString().ToLower()); 
		if(emitMode != null) { sb.AppendFormat (" {0}=\"{1}\"", "emitMode", (int)emitMode); }
		 sb.AppendFormat (" {0}=\"{1}\"", "adjustToFPS", adjustToFPS.ToString().ToLower()); 
		if(customScale != null) { sb.AppendFormat (" {0}=\"{1}\"", "customScale", customScale.Value.PUToString()); }
		if(imageMaskPath != null) { sb.AppendFormat (" {0}=\"{1}\"", "imageMaskPath", SecurityElement.Escape (imageMaskPath)); }

	}
	
	public override void gaxb_appendXMLSequences(StringBuilder sb)
	{
		base.gaxb_appendXMLSequences(sb);


	}
	
	public override void gaxb_appendXML(StringBuilder sb)
	{
		if(sb.Length == 0)
		{
			sb.AppendFormat ("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		}
		
		sb.AppendFormat ("<{0}", "Particles");
		
		if(xmlns != null) {
			if(parent == null) {
				sb.AppendFormat (" {0}=\"{1}\"", "xmlns", xmlns);
			}else{
				FieldInfo parentField = parent.GetType().GetField("xmlns");
				if(parentField != null && xmlns.Equals(parentField.GetValue(parent)) == false)
				{
					sb.AppendFormat (" {0}=\"{1}\"", "xmlns", xmlns);
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
			sb.AppendFormat (">{0}</{1}>", seq.ToString(), "Particles");
		}
	}
}
