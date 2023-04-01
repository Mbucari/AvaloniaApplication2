using Avalonia.Collections;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace AvaloniaApplication2.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public DataGridCollectionView CollectionView { get; }
		private readonly AvaloniaList<GridEntry> SOURCE = new();

		public MainWindowViewModel()
		{
			CollectionView = new DataGridCollectionView(SOURCE);

			SOURCE.Add(new GridEntry());
			SOURCE.Add(new GridEntry { ItemName = "Some Text" });

			CollectionView.GroupDescriptions.Add(new GroupDescription());
		}
	}
	
	public class GridEntry : ViewModelBase
	{
		public string? ItemName { get; set; }
		private bool? remove;
		public bool? Remove { get => remove; set => this.RaiseAndSetIfChanged(ref remove, value); }
	}

	public class GroupDescription : DataGridGroupDescription
	{
		public override object GroupKeyFromItem(object item, int level, CultureInfo culture)
		{
			var ge = item as GridEntry;

			return ge?.ItemName?.Length == 1 ? 1 : 2;
		}
	}
}
