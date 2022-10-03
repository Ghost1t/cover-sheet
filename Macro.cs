using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using TFlex.DOCs.Model.Macros.ObjectModel;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.Model.Technology.Macros.ObjectModel;
using TFlex.Reporting.CAD.MacroGenerator.ObjectModel;
using TFlex.Reporting.Technology.Macros;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.Macros;


public class Macro : ReportMacroProvider
{
	public Macro(ReportGenerationMacroContext context)
		: base(context)
	{
        //System.Diagnostics.Debugger.Launch();
        //System.Diagnostics.Debugger.Break();
	}
	
	Form Диалог = new Form();
	
	//Элементы Form
	private TextBox НомерСопровода = new TextBox ();
	private TextBox НомерЗаказа = new TextBox ();
	private TextBox КолВоДеталей = new TextBox ();
	private TextBox РазмерЗаготовки = new TextBox ();
	private TextBox НомерПлавки = new TextBox ();
	private TextBox НомерСертификата = new TextBox ();
	
	private Label LabelНомерСопровода = new Label();
	private Label LabelНомерЗаказа = new Label();
	private Label LabelКолВоДеталей = new Label();
	private Label LabelРазмерЗаготовки = new Label();
	private Label LabelНомерПлавки = new Label();
	private Label LabelНомерСертификата = new Label();
	
	private Button Продолжить = new Button ();
	
	
	
	public void Сопровод_03_001_2020()
	{

		
		//Button Продолжить
		Диалог.Controls.Add(Продолжить);
		Продолжить.Location = new Point (500/2-50, 220);
		Продолжить.Text = "Продолжить";
		Продолжить.Width = 100;
		Продолжить.Click += new EventHandler(Продолжить_Click);
		
		//TextBox НомерСопровода
		Диалог.Controls.Add(НомерСопровода);
		НомерСопровода.Location = new Point (225, 20);
		НомерСопровода.Width = 225;
		
		//TextBox НомерЗаказа
		Диалог.Controls.Add(НомерЗаказа);
		НомерЗаказа.Location = new Point (225, 50);
		НомерЗаказа.Width = 225;
		
		//TextBox КолВоДеталей
		Диалог.Controls.Add(КолВоДеталей);
		КолВоДеталей.Location = new Point (225, 80);
		КолВоДеталей.Width = 225;
		
		//TextBox РазмерЗаготовки
		Диалог.Controls.Add(РазмерЗаготовки);
		РазмерЗаготовки.Location = new Point (225, 110);
		РазмерЗаготовки.Width = 225;
		
		//TextBox НомерПлавки
		Диалог.Controls.Add(НомерПлавки);
		НомерПлавки.Location = new Point (225, 140);
		НомерПлавки.Width = 225;
		
		//TextBox НомерСертификата
		Диалог.Controls.Add(НомерСертификата);
		НомерСертификата.Location = new Point (225, 170);
		НомерСертификата.Width = 225;
		
		//Label LabelНомерСопровода
		Диалог.Controls.Add(LabelНомерСопровода);
		LabelНомерСопровода.Location = new Point (2, 22);
		LabelНомерСопровода.Width = 225;
		LabelНомерСопровода.Text = "Введите номер сопроводительного листа:";
		LabelНомерСопровода.TextAlign = ContentAlignment.TopRight;
		
		//Label LabelНомерЗаказа
		Диалог.Controls.Add(LabelНомерЗаказа);
		LabelНомерЗаказа.Location = new Point (2, 52);
		LabelНомерЗаказа.Width = 225;
		LabelНомерЗаказа.Text = "Введите номер заказа:";
		LabelНомерЗаказа.TextAlign = ContentAlignment.TopRight;
		
		//Label LabelКолВоДеталей
		Диалог.Controls.Add(LabelКолВоДеталей);
		LabelКолВоДеталей.Location = new Point (2, 82);
		LabelКолВоДеталей.Width = 225;
		LabelКолВоДеталей.Text = "Введите количество деталей:";
		LabelКолВоДеталей.TextAlign = ContentAlignment.TopRight;
		
		//Label LabelРазмерЗаготовки
		Диалог.Controls.Add(LabelРазмерЗаготовки);
		LabelРазмерЗаготовки.Location = new Point (2, 112);
		LabelРазмерЗаготовки.Width = 225;
		LabelРазмерЗаготовки.Text = "Введите размер заготовки:";
		LabelРазмерЗаготовки.TextAlign = ContentAlignment.TopRight;
		
		//Label LabelНомерПлавки
		Диалог.Controls.Add(LabelНомерПлавки);
		LabelНомерПлавки.Location = new Point (2, 142);
		LabelНомерПлавки.Width = 225;
		LabelНомерПлавки.Text = "Введите номер плавки:";
		LabelНомерПлавки.TextAlign = ContentAlignment.TopRight;
		
		//Label LabelНомерСертификата
		Диалог.Controls.Add(LabelНомерСертификата);
		LabelНомерСертификата.Location = new Point (2, 172);
		LabelНомерСертификата.Width = 225;
		LabelНомерСертификата.Text = "Введите номер сертификата:";
		LabelНомерСертификата.TextAlign = ContentAlignment.TopRight;
		
		//Form диалог
		Диалог.TopMost = true;
		Диалог.Text = "Ввод значений";
		Диалог.FormBorderStyle = FormBorderStyle.FixedDialog;
		Диалог.StartPosition = FormStartPosition.CenterScreen;
		Диалог.Size = new Size(500,300);
		Диалог.ShowDialog();
		
		
		
		
		//Запись значений в Шапку отчёта
		Переменная["$Обознач"] = ТекущийОбъект.Параметр["Обозначение ТП"];
		Переменная["$Наим"] = ТекущийОбъект.Параметр["Наименование"];
		ТехнологическийПроцесс техпроцесс2 = (ТехнологическийПроцесс)ТекущийОбъект;
		Материал[] материалы = техпроцесс2.Материалы;
		int количествоМатериалов = материалы.Length;
		if (количествоМатериалов > 0)
		{
			foreach (Объект материал in материалы)
			{
				Переменная["$Материал"] = материал.Параметр["Сводное наименование материала"];
			}
		}

		Объекты ДСЕ = ТекущийОбъект.СвязанныеОбъекты["Изготавливаемые ДСЕ"];
		if (ДСЕ.Count > 0)
		{
			string Кор = "";
			Кор = string.Join("; ", ДСЕ.Select(t => t["Короткое наименование"].ToString()).ToList());
			if (Кор != "")
			{
				Переменная["$Кор"] = Кор;
			}
			else
			{
				Переменная["$Кор"] = ТекущийОбъект["Наименование Кор"];
			}
		}
		else
		{
			Переменная["$Кор"] = ТекущийОбъект["Наименование Кор"];
		}

		
		var текст = Текст["Текст-1"];
		var шаблонОпер = текст["Наименование"];

		foreach (var операция in ТекущийОбъект.ДочерниеОбъекты)
		{
			var строкаОп = текст.Таблица.ДобавитьСтроку(шаблонОпер);
			строкаОп["Номер"].Текст = операция.Параметр["Номер"];
			строкаОп["Наименование"].Текст = операция.Параметр["Наименование"];
			if(операция.СвязанныйОбъект["30888ac1-d215-478f-aaf2-915be9aa9066"] != null)
				строкаОп["Цех"].Текст = операция.СвязанныйОбъект["30888ac1-d215-478f-aaf2-915be9aa9066"].Параметр["Номер"];
			
			if(операция.Параметр["Разряд опер"] != null && операция.Параметр["Разряд опер"] > 0)
				строкаОп["Разряд"].Текст = операция.Параметр["Разряд опер"];
			
			if(операция.Параметр["Штучное время"] != null && операция.Параметр["Штучное время"] > 0)
				строкаОп["Норма"].Текст = операция.Параметр["Штучное время"];
		}
		
	}
	
	
	private void Продолжить_Click(object sender, EventArgs e)
	{
		
		
		TextBox[] AllTextBox = new TextBox[] { НомерСопровода, НомерЗаказа, КолВоДеталей, РазмерЗаготовки, НомерПлавки, НомерСертификата};
		bool Error = false;
		foreach (var TextBox in AllTextBox)
		{
			if (TextBox.Text == "" || TextBox.Text.Trim() == string.Empty)
				Error = true;
		}
		
		
		
		if (Error == true)
			MessageBox.Show(Диалог, "Необходимо заполнить все поля!", "Внимание");
		else
		{
			//Закрытие Form
			Диалог.Close();
			
			//Запись значений в Шапку отчёта из TextBox
			Переменная["$НомерСопровода"] = НомерСопровода.Text;
			Переменная["$НомерЗаказа"] = НомерЗаказа.Text;
			Переменная["$КоличествоДеталей"] = КолВоДеталей.Text;
			Переменная["$РазмерЗаготовки"] = РазмерЗаготовки.Text;
			Переменная["$НомерПлавки"] = НомерПлавки.Text;
			Переменная["$НомерСертификата"] = НомерСертификата.Text;
		}
	}	
}