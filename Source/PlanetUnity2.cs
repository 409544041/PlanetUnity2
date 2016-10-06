

using UnityEngine;


//
// Autogenerated by gaxb ( https://github.com/SmallPlanet/gaxb )
//

using System.Xml;
using System.Text;
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;

interface IPlanetUnity2
{
	void gaxb_load(XmlReader reader, object _parent, Hashtable args);
	void gaxb_appendXML(StringBuilder sb);
}

public class PlanetUnity2 {
	public int baseRenderQueue = 0;

	public enum FontStyle {
		normal,
		bold,
		italic,
		boldAndItalic,
	};

	public enum GridTableHeuristic {
		RectBestShortSideFit,
		RectBestLongSideFit,
		RectBestAreaFit,
		RectBottomLeftRule,
		RectContactPointRule,
	};

	public enum AspectFitMode {
		None,
		WidthControlsHeight,
		HeightControlsWidth,
		FitInParent,
		EnvelopeParent,
	};

	public enum GridLayoutChildAlignment {
		upperLeft,
		upperCenter,
		upperRight,
		middleLeft,
		middleCenter,
		middleRight,
		lowerLeft,
		lowerCenter,
		lowerRight,
	};

	public enum ParticleEmitMode {
		SystemNone,
		SystemScaled,
		Edge,
		Fill,
		Center,
		Image,
	};

	public enum TextAlignment {
		upperLeft,
		upperCenter,
		upperRight,
		middleLeft,
		middleCenter,
		middleRight,
		lowerLeft,
		lowerCenter,
		lowerRight,
	};

	public enum GridLayoutStartAxis {
		horizontal,
		vertical,
	};

	public enum TextOverflowHorizontal {
		wrap,
		overflow,
	};

	public enum SliderDirection {
		LeftToRight,
		RightToLeft,
		BottomToTop,
		TopToBottom,
	};

	public enum InputFieldLineType {
		single,
		multiSubmit,
		multiNewline,
	};

	public enum InputFieldContentType {
		standard,
		autocorrected,
		integer,
		number,
		alphanumeric,
		name,
		email,
		password,
		pin,
		custom,
	};

	public enum GridLayoutStartCorner {
		upperLeft,
		upperRight,
		lowerLeft,
		lowerRight,
	};

	public const string USERSTRINGINPUT = "UserStringInput";
	public const string USERCHARINPUT = "UserCharInput";
	public const string USERINPUTCANCELLED = "UserInputCancelled";
	public const string BUTTONTOUCHDOWN = "ButtonTouchDown";
	public const string BUTTONTOUCHUP = "ButtonTouchUp";
	public const string EVENTWITHUNREGISTEREDCOLLIDER = "EventWithUnregisteredCollider";
	public const string EVENTWITHNOCOLLIDER = "EventWithNoCollider";
	public const string EDITORFILEDIDCHANGE = "EditorFileDidChange";

	public enum CanvasRenderMode {
		ScreenSpaceOverlay,
		ScreenSpaceCamera,
		WorldSpace,
	};

	public enum ImageType {
		simple,
		filled,
		sliced,
		tiled,
		aspectFilled,
	};

	public enum TextOverflowVertical {
		truncate,
		overflow,
	};



	static public string ConvertClassName(string xmlNamespace, string name)
	{
		return Regex.Replace(xmlNamespace, "[^A-Z]", "")+name;
	}
	
	static public T clone<T>(T root) {
		return (T)loadXML( writeXML (root), null, null);
	}
	
	static public string writeXML(object root) {
		StringBuilder sb = new StringBuilder ();
		MethodInfo mInfo = root.GetType().GetMethod("gaxb_appendXML");
		if(mInfo != null) {
			mInfo.Invoke (root, new[] { sb });
		}
		return sb.ToString();
	}

	static public object loadXML(string xmlString, object parentObject, Hashtable args, Action<object,object,XmlReader> customBlock)
		{
			object rootEntity = parentObject;
			object returnEntity = null;
			string xmlNamespace;

			// Create an XmlReader
			using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
			{
				// Parse the file and display each of the nodes.
				while (reader.Read())
				{
					switch (reader.NodeType)
					{
					case XmlNodeType.Element:
						xmlNamespace = Path.GetFileName (reader.NamespaceURI);
						try
						{
							Type entityClass = Type.GetType (ConvertClassName(xmlNamespace, reader.Name), true);
							PUObject entityObject = (PUObject)(Activator.CreateInstance (entityClass));

							if(customBlock == null){
								entityObject.gaxb_load(reader, rootEntity, args);
								entityObject.gaxb_init();
								entityObject.gaxb_final(reader, rootEntity, args);
							}else{
								customBlock(entityObject, rootEntity, reader);
							}

							if (reader.IsEmptyElement == false) {
								rootEntity = entityObject;
							} else {
								if(customBlock == null){
									entityObject.gaxb_complete();
									entityObject.gaxb_private_complete();
								}
							}

							if (rootEntity == null) {
								rootEntity = entityObject;
							}

							if(returnEntity == null) {
								returnEntity = entityObject;
							}
						}
						catch(TypeLoadException) {
							if (rootEntity != null) {
								// If we get here, this is not a unique object but perhaps a field on the parent...
								string valueName = reader.Name;
								if(rootEntity.GetType ().GetField (valueName) != null)
								{
									reader.Read();
									if ((reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA) && (reader.HasValue))
									{
										rootEntity.GetType ().GetField (valueName).SetValue (rootEntity, reader.Value);
									}
								}
								else
								{
									reader.Read();
									if ((reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA) && (reader.HasValue)) {
										List<object> parentChildren = (List<object>)(rootEntity.GetType ().GetField (valueName + "s").GetValue (rootEntity));
										if (parentChildren != null) {
											parentChildren.Add (reader.Value);
										}
									}
								}
							}
						}

						break;
					case XmlNodeType.Text:
						break;
					case XmlNodeType.XmlDeclaration:
					case XmlNodeType.ProcessingInstruction:
						break;
					case XmlNodeType.Comment:
						break;
					case XmlNodeType.EndElement:
						try{
							xmlNamespace = Path.GetFileName (reader.NamespaceURI);
							Type entityClass = Type.GetType (ConvertClassName(xmlNamespace, reader.Name), true);

							if(customBlock == null) {
								PUObject entityObject = rootEntity as PUObject;
								entityObject.gaxb_complete();
								entityObject.gaxb_private_complete();
							}

							if(entityClass != null)
							{
								object parent = rootEntity.GetType().GetField("parent").GetValue(rootEntity);
								if(parent != null)
								{
									rootEntity = parent;
								}
							}
						}catch(TypeLoadException) { }
						break;
					}
				}
			}

			return returnEntity;
		}
	
	static public object loadXML(string xmlString, object parentObject, Hashtable args)
	{
		return loadXML(xmlString, parentObject, args, null);
	}
}
