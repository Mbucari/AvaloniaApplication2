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
		private readonly List<GridEntry> SOURCE = new();

		public string Greeting => "Welcome to Avalonia!";

		public MainWindowViewModel()
		{
			CollectionView = new DataGridCollectionView(SOURCE);

			for (int i = 0; i < 20; i++)
				SOURCE.Add(new GridEntry { ItemName = i.ToString(), Remove = true });

			CollectionView.GroupDescriptions.Add(new GroupDescription());
		}
	}

	
	public class GridEntry : ViewModelBase
	{
		public string? ItemName { get; init; }
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
