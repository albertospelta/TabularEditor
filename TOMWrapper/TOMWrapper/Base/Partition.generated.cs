
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
///             Represents a partition in a table. Partitions define the query against external data sources that return the rowsets of a <see cref="T:TabularEditor.TOMWrapper.Table" />.
///             </summary>
	[TypeConverter(typeof(DynamicPropertyConverter))]
	public partial class Partition: TabularNamedObject
			, IErrorMessageObject
			, ITabularTableObject
			, IDescriptionObject
			, IAnnotationObject
			, IClonableObject
	{
	    protected internal new TOM.Partition MetadataObject { get { return base.MetadataObject as TOM.Partition; } internal set { base.MetadataObject = value; } }

/// <summary>
///             Gets the Type of PartitionSource.
///             </summary><returns>The Type of PartitionSource.</returns>
		[DisplayName("Source Type")]
		[Category("Other"),Description(@"Gets the Type of PartitionSource."),IntelliSense("The Source Type of this Partition.")]
		public TOM.PartitionSourceType SourceType {
			get {
			    return MetadataObject.SourceType;
			}
			
		}
		private bool ShouldSerializeSourceType() { return false; }
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
///             Gets or sets the Description property of the current column.
///             </summary><returns>The Description property of the current column.</returns>
		[DisplayName("Description")]
		[Category("Basic"),Description(@"Gets or sets the Description property of the current column."),IntelliSense("The Description of this Partition.")][Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
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
/// <summary>
///             Gets or sets the state for the object partitions. For regular partitions, Ready if the partition has been refreshed or NoData if it was never refreshed or if it was cleared. 
///             For calculated partitions, as with calculated columns, this value can be CalculationNeeded or Ready.
///             </summary><returns>The object state for the partitions.</returns>
		[DisplayName("State")]
		[Category("Metadata"),Description(@"Gets or sets the state for the object partitions. For regular partitions, Ready if the partition has been refreshed or NoData if it was never refreshed or if it was cleared. 
            For calculated partitions, as with calculated columns, this value can be CalculationNeeded or Ready."),IntelliSense("The State of this Partition.")]
		public TOM.ObjectState State {
			get {
			    return MetadataObject.State;
			}
			
		}
		private bool ShouldSerializeState() { return false; }
/// <summary>
///             Gets or sets the type of the model (import or DirectQuery).
///             </summary><returns>The type of the mode.</returns>
		[DisplayName("Mode")]
		[Category("Other"),Description(@"Gets or sets the type of the model (import or DirectQuery)."),IntelliSense("The Mode of this Partition.")]
		public TOM.ModeType Mode {
			get {
			    return MetadataObject.Mode;
			}
			set {
				var oldValue = Mode;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.MODE, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.Mode = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.MODE, oldValue, value));
				OnPropertyChanged(Properties.MODE, oldValue, value);
			}
		}
		private bool ShouldSerializeMode() { return false; }
/// <summary>
///             Gets or sets the type of data view that defines a partition slice.
///             </summary><returns>The type of data view that defines a partition slice.</returns>
		[DisplayName("Data View")]
		[Category("Other"),Description(@"Gets or sets the type of data view that defines a partition slice."),IntelliSense("The Data View of this Partition.")]
		public TOM.DataViewType DataView {
			get {
			    return MetadataObject.DataView;
			}
			set {
				var oldValue = DataView;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.DATAVIEW, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.DataView = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.DATAVIEW, oldValue, value));
				OnPropertyChanged(Properties.DATAVIEW, oldValue, value);
			}
		}
		private bool ShouldSerializeDataView() { return false; }
/// <summary>
///             Gets or sets an error message if the column is invalid or in an error state.
///             </summary><returns>An error message if the column is invalid or in an error state.</returns>
		[DisplayName("Error Message")]
		[Category("Metadata"),Description(@"Gets or sets an error message if the column is invalid or in an error state."),IntelliSense("The Error Message of this Partition.")]
		public string ErrorMessage {
			get {
			    return MetadataObject.ErrorMessage;
			}
			
		}
		private bool ShouldSerializeErrorMessage() { return false; }

		[DisplayName("Retain Data Till Force Calculate")]
		[Category("Other"),Description(@""),IntelliSense("The Retain Data Till Force Calculate of this Partition.")]
		public bool RetainDataTillForceCalculate {
			get {
			    return MetadataObject.RetainDataTillForceCalculate;
			}
			set {
				var oldValue = RetainDataTillForceCalculate;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.RETAINDATATILLFORCECALCULATE, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.RetainDataTillForceCalculate = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.RETAINDATATILLFORCECALCULATE, oldValue, value));
				OnPropertyChanged(Properties.RETAINDATATILLFORCECALCULATE, oldValue, value);
			}
		}
		private bool ShouldSerializeRetainDataTillForceCalculate() { return false; }
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


		public static Partition CreateFromMetadata(TOM.Partition metadataObject, bool init = true) {
			var obj = new Partition(metadataObject, init);
			if(init) 
			{
				obj.InternalInit();
				obj.Init();
			}
			return obj;
		}


		/// <summary>
		/// Creates a new Partition and adds it to the parent Table.
		/// Also creates the underlying metadataobject and adds it to the TOM tree.
		/// </summary>
		public static Partition CreateNew(Table parent, string name = null)
		{
			var metadataObject = new TOM.Partition();
			metadataObject.Name = parent.Partitions.GetNewName(string.IsNullOrWhiteSpace(name) ? "New Partition" : name);

			var obj = new Partition(metadataObject);

			parent.Partitions.Add(obj);
			
			obj.Init();

			return obj;
		}


		/// <summary>
		/// Creates an exact copy of this Partition object.
		/// </summary>
		public Partition Clone(string newName = null, Table newParent = null) {
		    Handler.BeginUpdate("Clone Partition");

			// Create a clone of the underlying metadataobject:
			var tom = MetadataObject.Clone() as TOM.Partition;


			// Assign a new, unique name:
			tom.Name = Parent.Partitions.MetadataObjectCollection.GetNewName(string.IsNullOrEmpty(newName) ? tom.Name + " copy" : newName);
				
			// Create the TOM Wrapper object, representing the metadataobject (but don't init until after we add it to the parent):
			var obj = CreateFromMetadata(tom, false);

			// Add the object to the parent collection:
			if(newParent != null) 
				newParent.Partitions.Add(obj);
			else
    			Parent.Partitions.Add(obj);

			obj.InternalInit();
			obj.Init();


            Handler.EndUpdate();

            return obj;
		}

		TabularNamedObject IClonableObject.Clone(string newName, bool includeTranslations, TabularNamedObject newParent) 
		{
			if (includeTranslations) throw new ArgumentException("This object does not support translations", "includeTranslations");
			return Clone(newName);
		}

	
        internal override void RenewMetadataObject()
        {
            Handler.WrapperLookup.Remove(MetadataObject);
            MetadataObject = MetadataObject.Clone() as TOM.Partition;
            Handler.WrapperLookup.Add(MetadataObject, this);
        }

		public Table Parent { 
			get {
				return Handler.WrapperLookup[MetadataObject.Parent] as Table;
			}
		}



		/// <summary>
		/// CTOR - only called from static factory methods on the class
		/// </summary>
		protected Partition(TOM.Partition metadataObject, bool init = true) : base(metadataObject)
		{
			if(init) InternalInit();
		}

		private void InternalInit()
		{
			
			// Create indexer for annotations:
			Annotations = new AnnotationCollection(this);
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
				
				default:
					return base.Browsable(propertyName);
			}
		}

    }


	/// <summary>
	/// Collection class for Partition. Provides convenient properties for setting a property on multiple objects at once.
	/// </summary>
	public partial class PartitionCollection: TabularObjectCollection<Partition, TOM.Partition, TOM.Table>
	{
		public override TabularNamedObject Parent { get { return Table; } }
		public Table Table { get; protected set; }
		public PartitionCollection(string collectionName, TOM.PartitionCollection metadataObjectCollection, Table parent) : base(collectionName, metadataObjectCollection)
		{
			Table = parent;
		}

		internal override void Reinit() {
			for(int i = 0; i < Count; i++) {
				var item = this[i];
				Handler.WrapperLookup.Remove(item.MetadataObject);
				item.MetadataObject = Table.MetadataObject.Partitions[i] as TOM.Partition;
				Handler.WrapperLookup.Add(item.MetadataObject, item);
				item.Collection = this;
			}
			MetadataObjectCollection = Table.MetadataObject.Partitions;
			foreach(var item in this) item.Reinit();
		}

		internal override void ReapplyReferences() {
			foreach(var item in this) item.ReapplyReferences();
		}

		/// <summary>
		/// Calling this method will populate the PartitionCollection with objects based on the MetadataObjects in the corresponding MetadataObjectCollection.
		/// </summary>
		public override void CreateChildrenFromMetadata()
		{
			// Construct child objects (they are automatically added to the Handler's WrapperLookup dictionary):
			foreach(var obj in MetadataObjectCollection) {
				Partition.CreateFromMetadata(obj).Collection = this;
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
		[Description("Sets the Mode property of all objects in the collection at once.")]
		public TOM.ModeType Mode {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("Mode"));
				this.ToList().ForEach(item => { item.Mode = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the DataView property of all objects in the collection at once.")]
		public TOM.DataViewType DataView {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("DataView"));
				this.ToList().ForEach(item => { item.DataView = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the RetainDataTillForceCalculate property of all objects in the collection at once.")]
		public bool RetainDataTillForceCalculate {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("RetainDataTillForceCalculate"));
				this.ToList().ForEach(item => { item.RetainDataTillForceCalculate = value; });
				Handler.UndoManager.EndBatch();
			}
		}

		public override string ToString() {
			return string.Format("({0} {1})", Count, (Count == 1 ? "Partition" : "Partitions").ToLower());
		}
	}
}
