# How to Discard all the Changes in WPF Spreadsheet?

This sample explains how to undo and redo all the unsaved changes in [WPF Spreadsheet](https://www.syncfusion.com/wpf-controls/spreadsheet) (SfSpreadsheet).

By default, all the unsaved changes are maintained in the **UndoStack** commands collection.  To discard all the unsaved changes programmatically, **Execute** the all commands in **UndoStack** collection. By executing the commands in **RedoStack** commands collection, all the discarded changes can be retrieved.

``` c#
//UndoAll the changes
while (this.spreadsheetControl.HistoryManager.UndoStack.Count > 0) 
{ 
   var undo = this.spreadsheetControl.HistoryManager.UndoStack.Pop(); 
   if (undo != null) 
   { 
        undo.Execute(Syncfusion.UI.Xaml.Spreadsheet.History.CommandMode.Undo); 
   } 
}
 
//RedoAll the changes
while (this.spreadsheetControl.HistoryManager.RedoStack.Count > 0) 
{ 
    var redo = this.spreadsheetControl.HistoryManager.RedoStack.Pop(); 
    if (redo != null) 
    {
        redo.Execute(Syncfusion.UI.Xaml.Spreadsheet.History.CommandMode.Redo); 
    }
}
```
