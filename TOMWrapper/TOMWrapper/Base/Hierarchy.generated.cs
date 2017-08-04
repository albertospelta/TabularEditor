
// Code generated by a template
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using TabularEditor.PropertyGridUI;
using TabularEditor.UndoFramework;
using System.Drawing.Design;
using TOM = Microsoft.AnalysisServices.Tabular;
namespace TabularEditor.TOMWrapper
{
  
	/// <summary>
///             Represents a collection of levels that provide a logical hierarchical drilldown path for client applications. It is a child of a Table object.
///             </summary>
	[TypeConverter(typeof(DynamicPropertyConverter))]
	public partial class Hierarchy: TabularNamedObject
			, IDetailObject
			, IHideableObject
			, ITabularTableObject
			, IDescriptionObject
			, IAnnotationObject
			, ITabularPerspectiveObject
			, ITranslatableObject
			, IClonableObject
	{
	    protected internal new TOM.Hierarchy MetadataObject { get { return base.MetadataObject as TOM.Hierarchy; } internal set { base.MetadataObject = value; } }

        [Browsable(true),NoMultiselect,Category("Translations and Perspectives"),Description("The collection of Annotations on this object."),Editor(typeof(AnnotationCollectionEditor), typeof(UITypeEditor))]
		public AnnotationCollection Annotations { get; private set; }
		public string GetAnnotation(int index) {
			return MetadataObject.Annotations[index].Value;
		}
		public string GetAnnotation(string name) {
		    return MetadataObject.Annotations.ContainsName(name) ? MetadataObject.Annotations[name].Value : null;
		}
		public void SetAnnotation(int index, string value, bool undoable = true) {
			var name = MetadataObject.Annotations[index].Name;
			SetAnnotation(name, value, undoable);
		}
		public string GetNewAnnotationName() {
			return MetadataObject.Annotations.GetNewName("New Annotation");
		}
		public void SetAnnotation(string name, string value, bool undoable = true) {
			if(name == null) name = GetNewAnnotationName();

			if(value == null) {
				// Remove annotation if set to null:
				RemoveAnnotation(name, undoable);
				return;
			}

			if(GetAnnotation(name) == value) return;
			bool undoable2 = true;
			bool cancel = false;
			OnPropertyChanging(Properties.ANNOTATIONS, name + ":" + value, ref undoable2, ref cancel);
			if (cancel) return;

			if(MetadataObject.Annotations.Contains(name)) {
				// Change existing annotation:
				var oldValue = GetAnnotation(name);
				MetadataObject.Annotations[name].Value = value;
				if (undoable) Handler.UndoManager.Add(new UndoAnnotationAction(this, name, value, oldValue));
				OnPropertyChanged(Properties.ANNOTATIONS, name + ":" + oldValue, name + ":" + value);
			} else {
				// Add new annotation:
				MetadataObject.Annotations.Add(new TOM.Annotation{ Name = name, Value = value });
				if (undoable) Handler.UndoManager.Add(new UndoAnnotationAction(this, name, value, null));
				OnPropertyChanged(Properties.ANNOTATIONS, null, name + ":" + value);
			}

		}
		public void RemoveAnnotation(string name, bool undoable = true) {
			if(MetadataObject.Annotations.Contains(name)) {
				// Get current value:
				bool undoable2 = true;
				bool cancel = false;
				OnPropertyChanging(Properties.ANNOTATIONS, name + ":" + GetAnnotation(name), ref undoable2, ref cancel);
				if (cancel) return;

				var oldValue = MetadataObject.Annotations[name].Value;
				MetadataObject.Annotations.Remove(name);

				// Undo-handling:
				if (undoable) Handler.UndoManager.Add(new UndoAnnotationAction(this, name, null, oldValue));
				OnPropertyChanged(Properties.ANNOTATIONS, name + ":" + oldValue, null);
			}
		}
		public int GetAnnotationsCount() {
			return MetadataObject.Annotations.Count;
		}
		public IEnumerable<string> GetAnnotations() {
			return MetadataObject.Annotations.Select(a => a.Name);
		}

		/// <summary>
///             Gets or sets the description of the <see cref="T:TabularEditor.TOMWrapper.Hierarchy" /> object.
///             </summary><returns>The description of the <see cref="T:TabularEditor.TOMWrapper.Hierarchy" /> object.</returns>
		[DisplayName("Description")]
		[Category("Basic"),Description(@"Gets or sets the description of the Hierarchy object."),IntelliSense("The Description of this Hierarchy.")][Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string Description {
			get {
			    return MetadataObject.Description;
			}
			set {
				var oldValue = Description;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.DESCRIPTION, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.Description = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.DESCRIPTION, oldValue, value));
				OnPropertyChanged(Properties.DESCRIPTION, oldValue, value);
			}
		}
		private bool ShouldSerializeDescription() { return false; }
/// <summary>Gets or sets a value that indicates whether the hierarchy is hidden.</summary><returns>true if the hierarchy is hidden; otherwise, false.</returns>
		[DisplayName("Hidden")]
		[Category("Basic"),Description(@"Gets or sets a value that indicates whether the hierarchy is hidden."),IntelliSense("The Hidden of this Hierarchy.")]
		public bool IsHidden {
			get {
			    return MetadataObject.IsHidden;
			}
			set {
				var oldValue = IsHidden;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.ISHIDDEN, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.IsHidden = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.ISHIDDEN, oldValue, value));
				OnPropertyChanged(Properties.ISHIDDEN, oldValue, value);
				Handler.UpdateObject(this);
			}
		}
		private bool ShouldSerializeIsHidden() { return false; }
/// <summary>Gets or sets the object state.</summary><returns>An object state.</returns>
		[DisplayName("State")]
		[Category("Metadata"),Description(@"Gets or sets the object state."),IntelliSense("The State of this Hierarchy.")]
		public TOM.ObjectState State {
			get {
			    return MetadataObject.State;
			}
			
		}
		private bool ShouldSerializeState() { return false; }
/// <summary>
///             Gets or sets the display folder.
///             </summary><returns>The display folder.</returns>
		[DisplayName("Display Folder")]
		[Category("Basic"),Description(@"Gets or sets the display folder."),IntelliSense("The Display Folder of this Hierarchy.")][Editor(typeof(CustomDialogEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string DisplayFolder {
			get {
			    return MetadataObject.DisplayFolder;
			}
			set {
				var oldValue = DisplayFolder;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.DISPLAYFOLDER, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.DisplayFolder = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.DISPLAYFOLDER, oldValue, value));
				OnPropertyChanged(Properties.DISPLAYFOLDER, oldValue, value);
				Handler.UpdateFolders(Table);
			}
		}
		private bool ShouldSerializeDisplayFolder() { return false; }
        /// <summary>
        /// Collection of localized Display Folders for this Hierarchy.
        /// </summary>
        [Browsable(true),DisplayName("Translated Display Folders"),Description("Shows all translated Display Folders of this object."),Category("Translations and Perspectives")]
	    public TranslationIndexer TranslatedDisplayFolders { private set; get; }

		[DisplayName("Hide Members")]
		[Category("Other"),Description(@""),IntelliSense("The Hide Members of this Hierarchy.")]
		public TOM.HierarchyHideMembersType HideMembers {
			get {
			    return MetadataObject.HideMembers;
			}
			set {
				var oldValue = HideMembers;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.HIDEMEMBERS, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.HideMembers = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.HIDEMEMBERS, oldValue, value));
				OnPropertyChanged(Properties.HIDEMEMBERS, oldValue, value);
			}
		}
		private bool ShouldSerializeHideMembers() { return false; }
		[Browsable(false)]
		public Table Table
		{ 
			get 
			{ 
				TabularObject t = null;
				if(MetadataObject == null || MetadataObject.Table == null) return null;
				if(!Handler.WrapperLookup.TryGetValue(MetadataObject.Table, out t)) {
				    t = Model.Tables[MetadataObject.Table.Name];
				}
				return t as Table;
			} 
		}

        /// <Summary>
		/// Collection of perspectives in which this Hierarchy is visible.
		/// </Summary>
		[Browsable(true),DisplayName("Shown in Perspective"), Description("Provides an easy way to include or exclude this object from the perspectives of the model."), Category("Translations and Perspectives")]
        public PerspectiveIndexer InPerspective { get; private set; }
        /// <summary>
        /// Collection of localized descriptions for this Hierarchy.
        /// </summary>
        [Browsable(true),DisplayName("Translated Descriptions"),Description("Shows all translated descriptions of this object."),Category("Translations and Perspectives")]
	    public TranslationIndexer TranslatedDescriptions { private set; get; }
        /// <summary>
        /// Collection of localized names for this Hierarchy.
        /// </summary>
        [Browsable(true),DisplayName("Translated Names"),Description("Shows all translated names of this object."),Category("Translations and Perspectives")]
	    public TranslationIndexer TranslatedNames { private set; get; }


		public static Hierarchy CreateFromMetadata(TOM.Hierarchy metadataObject, bool init = true) {
			var obj = new Hierarchy(metadataObject, init);
			if(init) 
			{
				obj.InternalInit();
				obj.Init();
			}
			return obj;
		}


		/// <summary>
		/// Creates a new Hierarchy and adds it to the parent Table.
		/// Also creates the underlying metadataobject and adds it to the TOM tree.
		/// </summary>
		public static Hierarchy CreateNew(Table parent, string name = null)
		{
			var metadataObject = new TOM.Hierarchy();
			metadataObject.Name = parent.Hierarchies.GetNewName(string.IsNullOrWhiteSpace(name) ? "New Hierarchy" : name);

			var obj = new Hierarchy(metadataObject);

			parent.Hierarchies.Add(obj);
			
			obj.Init();

			return obj;
		}


		/// <summary>
		/// Creates an exact copy of this Hierarchy object.
		/// </summary>
		public Hierarchy Clone(string newName = null, bool includeTranslations = true, Table newParent = null) {
		    Handler.BeginUpdate("Clone Hierarchy");

			// Create a clone of the underlying metadataobject:
			var tom = MetadataObject.Clone() as TOM.Hierarchy;


			// Assign a new, unique name:
			tom.Name = Parent.Hierarchies.MetadataObjectCollection.GetNewName(string.IsNullOrEmpty(newName) ? tom.Name + " copy" : newName);
				
			// Create the TOM Wrapper object, representing the metadataobject (but don't init until after we add it to the parent):
			var obj = CreateFromMetadata(tom, false);

			// Add the object to the parent collection:
			if(newParent != null) 
				newParent.Hierarchies.Add(obj);
			else
    			Parent.Hierarchies.Add(obj);

			obj.InternalInit();
			obj.Init();

			// Copy translations, if applicable:
			if(includeTranslations) {
				// TODO: Copy translations of child objects

				obj.TranslatedNames.CopyFrom(TranslatedNames);
				obj.TranslatedDescriptions.CopyFrom(TranslatedDescriptions);
				obj.TranslatedDisplayFolders.CopyFrom(TranslatedDisplayFolders);
			}
				
			// Copy perspectives:
			obj.InPerspective.CopyFrom(InPerspective);

            Handler.EndUpdate();

            return obj;
		}

		TabularNamedObject IClonableObject.Clone(string newName, bool includeTranslations, TabularNamedObject newParent) 
		{
			return Clone(newName, includeTranslations);
		}

	
        internal override void RenewMetadataObject()
        {
            Handler.WrapperLookup.Remove(MetadataObject);
            MetadataObject = MetadataObject.Clone() as TOM.Hierarchy;
            Handler.WrapperLookup.Add(MetadataObject, this);
        }

		public Table Parent { 
			get {
				return Handler.WrapperLookup[MetadataObject.Parent] as Table;
			}
		}

        internal override ITabularObjectCollection GetCollectionForChild(TabularObject child)
        {
			if (child is Level) return Levels;
            return base.GetCollectionForChild(child);
        }

        /// <summary>
        /// The collection of Level objects on this Hierarchy.
        /// </summary>
		[DisplayName("Levels")]
		[Category("Other"),IntelliSense("The collection of Level objects on this Hierarchy.")][Browsable(false)]
		public LevelCollection Levels { get; protected set; }

		/// <summary>
		/// CTOR - only called from static factory methods on the class
		/// </summary>
		protected Hierarchy(TOM.Hierarchy metadataObject, bool init = true) : base(metadataObject)
		{
			if(init) InternalInit();
		}

		private void InternalInit()
		{
			// Create indexers for translations:
			TranslatedNames = new TranslationIndexer(this, TOM.TranslatedProperty.Caption);
			TranslatedDescriptions = new TranslationIndexer(this, TOM.TranslatedProperty.Description);
			TranslatedDisplayFolders = new TranslationIndexer(this, TOM.TranslatedProperty.DisplayFolder);

			// Create indexer for perspectives:
			InPerspective = new PerspectiveHierarchyIndexer(this);
			
			// Create indexer for annotations:
			Annotations = new AnnotationCollection(this);
			
			// Instantiate child collections:
			Levels = new LevelCollection(this.GetObjectPath() + ".Levels", MetadataObject.Levels, this);

			// Populate child collections:
			Levels.CreateChildrenFromMetadata();

			// Hook up event handlers on child collections:
			Levels.CollectionChanged += Children_CollectionChanged;
		}


		internal override void Reinit() {
			Levels.Reinit();
		}

		internal override void Undelete(ITabularObjectCollection collection) {
			base.Undelete(collection);
			Reinit();
			ReapplyReferences();
		}

		public override bool Browsable(string propertyName) {
			switch (propertyName) {
				case Properties.PARENT:
					return false;
				
				// Hides translation properties in the grid, unless the model actually contains translations:
				case Properties.TRANSLATEDNAMES:
				case Properties.TRANSLATEDDESCRIPTIONS:
				case Properties.TRANSLATEDDISPLAYFOLDERS:
					return Model.Cultures.Any();
				
				// Hides the perspective property in the grid, unless the model actually contains perspectives:
				case Properties.INPERSPECTIVE:
					return Model.Perspectives.Any();
				
				default:
					return base.Browsable(propertyName);
			}
		}

    }


	/// <summary>
	/// Collection class for Hierarchy. Provides convenient properties for setting a property on multiple objects at once.
	/// </summary>
	public partial class HierarchyCollection: TabularObjectCollection<Hierarchy, TOM.Hierarchy, TOM.Table>
	{
		public override TabularNamedObject Parent { get { return Table; } }
		public Table Table { get; protected set; }
		public HierarchyCollection(string collectionName, TOM.HierarchyCollection metadataObjectCollection, Table parent) : base(collectionName, metadataObjectCollection)
		{
			Table = parent;
		}

		internal override void Reinit() {
			for(int i = 0; i < Count; i++) {
				var item = this[i];
				Handler.WrapperLookup.Remove(item.MetadataObject);
				item.MetadataObject = Table.MetadataObject.Hierarchies[i] as TOM.Hierarchy;
				Handler.WrapperLookup.Add(item.MetadataObject, item);
				item.Collection = this;
			}
			MetadataObjectCollection = Table.MetadataObject.Hierarchies;
			foreach(var item in this) item.Reinit();
		}

		internal override void ReapplyReferences() {
			foreach(var item in this) item.ReapplyReferences();
		}

		/// <summary>
		/// Calling this method will populate the HierarchyCollection with objects based on the MetadataObjects in the corresponding MetadataObjectCollection.
		/// </summary>
		public override void CreateChildrenFromMetadata()
		{
			// Construct child objects (they are automatically added to the Handler's WrapperLookup dictionary):
			foreach(var obj in MetadataObjectCollection) {
				Hierarchy.CreateFromMetadata(obj).Collection = this;
			}
		}

		[Description("Sets the Description property of all objects in the collection at once.")]
		public string Description {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("Description"));
				this.ToList().ForEach(item => { item.Description = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the IsHidden property of all objects in the collection at once.")]
		public bool IsHidden {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("IsHidden"));
				this.ToList().ForEach(item => { item.IsHidden = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the DisplayFolder property of all objects in the collection at once.")]
		public string DisplayFolder {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("DisplayFolder"));
				this.ToList().ForEach(item => { item.DisplayFolder = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the HideMembers property of all objects in the collection at once.")]
		public TOM.HierarchyHideMembersType HideMembers {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("HideMembers"));
				this.ToList().ForEach(item => { item.HideMembers = value; });
				Handler.UndoManager.EndBatch();
			}
		}

		public override string ToString() {
			return string.Format("({0} {1})", Count, (Count == 1 ? "Hierarchy" : "Hierarchies").ToLower());
		}
	}
}
