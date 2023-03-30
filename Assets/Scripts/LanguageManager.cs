using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    [System.Serializable]
    public class Main
    {
        public Text Title;
        public Text Section1;
        public Text EatButton;
        public Text HighButton;
        public Text Section2;
        public Text LowButton;
        public Text Section3;
        public Text ChangeButton;
        public Text MoreInfo;
        public Text CloseButton;
    }

    [System.Serializable]
    public class High
    {
        public Text Title;
        public Text PlaceHolderHigh;
        public Text PlaceHolderNormal;
        public Text CalculateButton;
        public Text BackButton;
        public Text Result;
        public Text NoticeResult;
        public Text WrongInput;
        public Text MissingInfo;
        public Text DrSuggestion;
    }
    
    [System.Serializable]
    public class Eat
    {
        public Text Title;
        public Text PlaceHolderActualGlucoseLevel;
        public Text GlLevel;
        public Text PlaceHolderCarbsEaten;
        public Text CarbsEaten;
        public Text CalculateButton;
        public Text BackButton;
        public Text Result;
        public Text NoticeResult;
        public Text MissingInfo;
        public Text Attention;
    }

    [System.Serializable]
    public class Low
    {
        public Text Title;
        public Text PlaceHolderLow;
        public Text PlaceHolderNormal;
        public Text CalculateButton;
        public Text BackButton;
        public Text Result;
        public Text NoticeResult;
        public Text WrongInput;
        public Text MissingInfo;
        public Text DrSuggestion;
    }

    [System.Serializable]
    public class Information
    {
        public Text Title;
        public Text Content;
        public Text BackButton;
    }

    [System.Serializable]
    public class Ratio
    {
        public Text Title;
        public Text WeightText;
        public Text UI_1;
        public Text UI_2;
        public Text UI_3;
        public Text UI_4;
        public Text Breakfest;
        public Text Lunch;
        public Text Dinner;
        public Text GlucoseLevel;
        public Text CorrectionBolus;
        public Text Carbs1;
        public Text Carbs2;
        public Text Carbs3;
        public Text CancelButton;
        public Text ConfirmButton;
    }

    [System.Serializable]
    public class Languages
    {
        public Text Title;
        public Text BackButton;
    }

    public Main main;
    public High high;
    public Eat eat;
    public Low low;
    public Information info;
    public Ratio ratio;
    public Languages lang;

    private void Start()
    {
        OnStart();
    }

    public void OnStart()
    {
        if (PlayerPrefs.GetString("language", "english") == "english")
            English();
        else if (PlayerPrefs.GetString("language", "english") == "french")
            French();
        else if (PlayerPrefs.GetString("language", "english") == "romana")
            Romana();
    }

    public void English()
    {
        PlayerPrefs.SetString("language", "english");

        //main panel
        main.Title.text = "Calculator\nfor\nDiabetics";
        main.Section1.text = "Calculate Insulin for:";
        main.EatButton.text = "Carbohydrates eaten";
        main.HighButton.text = "High Glucose";
        main.Section2.text = "How much to eat for:";
        main.LowButton.text = "Low Glucose";
        main.Section3.text = "Change insulin to carbs ratio:";
        main.ChangeButton.text = "Change";
        main.MoreInfo.text = "More Info";
        main.CloseButton.text = "Close";

        //high panel
        high.Title.text = "Downgrade your Glucose level";
        high.PlaceHolderHigh.text = "Enter your\nhigh glucose...";
        high.PlaceHolderNormal.text = "Enter the ideal\nglucose level...";
        high.CalculateButton.text = "Calculate";
        high.BackButton.text = "Back";
        high.Result.text = "0UI";
        high.NoticeResult.text = "This is a aproximation based on the formula:\n1 unit lowers 30\nmg / dl";
        high.WrongInput.text = "Wrong Input\nTry again!!!";
        high.MissingInfo.text = "Missing Information\nTry again!!!";
        high.DrSuggestion.text = "Your Glucose Level is too High\nCall a doctor!!!\nAnd follow his instructions";

        //eat panel
        eat.Title.text = "Insulin for CARBS\nCalculator";
        eat.PlaceHolderActualGlucoseLevel.text = "Your Glucose Level:";
        eat.GlLevel.text = "(glucose level)";
        eat.PlaceHolderCarbsEaten.text = "Carbs to eat:";
        eat.CarbsEaten.text = "(Carbs)";
        eat.CalculateButton.text = "Calculate";
        eat.BackButton.text = "Back";
        eat.Result.text = "0UI";
        eat.NoticeResult.text = "The result is based on your typical insulin dose per 10 Carbs, but if you practised sport before eating, this is just an aproximation.";
        eat.NoticeResult.fontSize = 25;
        eat.MissingInfo.text = "Missing Information\nTry again!!!";
        eat.Attention.text = "*you Shouldn't eat with glucose level above 150 mg/DL (8.3 mmol/L)";

        //low panel
        low.Title.text = "Increase\nyour Glucose\nlevel";
        low.PlaceHolderLow.text = "Enter your\nlow glucose...";
        low.PlaceHolderNormal.text = "Enter the ideal\nglucose level...";
        low.CalculateButton.text = "Calculate";
        low.BackButton.text = "Back";
        low.Result.text = "You should eat:\n0Carbs";
        low.Result.fontSize = 29;
        low.NoticeResult.text = "Remember that this is an aproximation and the program doesn't know if you practised sport or just eaten or etc. Please make sure the calculations are the same the ones you usually make.";
        low.WrongInput.text = "Wrong Input\nTry again!!!";
        low.MissingInfo.text = "Missing Information\nTry again!!!";
        low.DrSuggestion.text = "Your Glucose Level is too Low\nCall a doctor!!!\nAnd follow his instructions";

        //info panel
        info.Title.text = "Information";
        info.Content.text = " -	Your Information isn't collected anywhere and the app accesses only the time of your devices.\n- This is not a 100 % Accuarte app, it is just an aproximation for you and a helper for calculations.\n- note that it isn't the developers fault that your HbA1c may rise.\n- The developer made this app by reading about diabetes, talking to doctors about it and he has also diabetes.\n- This app has been tested by three people with diabetes.";
        info.BackButton.text = "Back";
        info.Content.fontSize = 24;

        //ratio panel
        ratio.Title.text = "User Information";
        ratio.WeightText.text = "Body weight\n(kg or lbs)";
        ratio.UI_1.text = "(units)";
        ratio.UI_2.text = ratio.UI_1.text;
        ratio.UI_3.text = ratio.UI_1.text;
        ratio.UI_4.text = ratio.UI_1.text;
        ratio.Breakfest.text = "Breakfest insulin Dose: UI / 10Carbs";
        ratio.Lunch.text = "Lunch insulin Dose: UI / 10Carbs";
        ratio.Dinner.text = "Dinner insulin Dose: UI / 10Carbs";
        ratio.GlucoseLevel.text = "Change Glucose\nlevel unit";
        ratio.CorrectionBolus.text = "Enter your correction Bolus ";
        ratio.Carbs1.text = "10\nCarbs";
        ratio.Carbs2.text = ratio.Carbs1.text;
        ratio.Carbs3.text = ratio.Carbs1.text;
        ratio.CancelButton.text = "Cancel";
        ratio.ConfirmButton.text = "Confirm";
        ratio.ConfirmButton.fontSize = 25;

        //languages panel
        lang.Title.text = "Change Language";
        lang.BackButton.text = "Back";
    }

    //_______________________________________________________________________________________________________________________________________
    //_______________________________________________________________________________________________________________________________________

    public void Greek()
    {
        PlayerPrefs.SetString("language", "greek");

        //main panel
        main.Title.text = "Αριθμομηχανή\nγια\nΔιαβητικούς";
        main.Section1.text = "Υπολογισμός ινσουλίνης για: ";
        main.EatButton.text = "Υδατάνθρακες που καταναλώνονται";
        main.HighButton.text = "Υψηλή γλυκόζη";
        main.Section2.text = "Πόσο να φάτε για:";
        main.LowButton.text = "Χαμηλή γλυκόζη";
        main.Section3.text = "Αλλαγή της αναλογίας ινσουλίνης προς υδατάνθρακες:";
        main.ChangeButton.text = "Αλλαγή";
        main.MoreInfo.text = "Πληροφορίες";
        main.CloseButton.text = "Κλείσε";

        //high panel
        high.Title.text = "Υποβαθμίστε το επίπεδο γλυκόζης σας";
        high.PlaceHolderHigh.text = "Καταχώρησε\nυψηλή γλυκόζη...";
        high.PlaceHolderNormal.text = "Εισάγετε το ιδανικό\nεπίπεδο γλυκόζης...";
        high.CalculateButton.text = "Υπολογίζω";
        high.BackButton.text = "Πίσω";
        high.Result.text = "0UI";
        high.NoticeResult.text = "Αυτή είναι μια προσέγγιση που βασίζεται στον τύπο:\n1 μονάδα χαμηλώνει 30\nmg / dl";
        high.WrongInput.text = "Λάθος εισαγωγή\nΠροσπάθησε ξανά!!!";
        high.MissingInfo.text = "Ελλειπείς πληροφορίες\nΠροσπάθησε ξανά!!!";
        high.DrSuggestion.text = "Το επίπεδο γλυκόζης σας είναι πολύ υψηλό\nΚαλέστε έναν γιατρό!!!\nΚαι ακολουθήστε τις οδηγίες του";

        //eat panel
        eat.Title.text = "Ινσουλίνη για υδατάνθρακες\nΑριθμομηχανή";
        eat.PlaceHolderActualGlucoseLevel.text = "Το επίπεδο γλυκόζης σας:";
        eat.GlLevel.text = "(επίπεδο γλυκόζης)";
        eat.PlaceHolderCarbsEaten.text = "Υδατάνθρακες προς κατανάλωση:";
        eat.CarbsEaten.text = "(Υδατάνθρακες)";
        eat.CalculateButton.text = "Υπολογίζω";
        eat.BackButton.text = "Πίσω";
        eat.Result.text = "0UI";
        eat.NoticeResult.text = "Το αποτέλεσμα βασίζεται στην τυπική σας δόση ινσουλίνης ανά 10 Υδατάνθρακες, αλλά αν κάνατε αθλητισμό πριν φάτε, αυτό είναι απλώς μια προσέγγιση.";
        eat.NoticeResult.fontSize = 25;
        eat.MissingInfo.text = "Ελλειπείς πληροφορίες\nΠροσπάθησε ξανά!!!";
        eat.Attention.text = "*Δεν πρέπει να τρώτε με υψηλότερο επίπεδο γλυκόζης 150 mg/DL (8.3 mmol/L)";

        //low panel
        low.Title.text = "Increase\nyour Glucose\nlevel";
        low.PlaceHolderLow.text = "Enter your\nlow glucose...";
        low.PlaceHolderNormal.text = "Enter the ideal\nglucose level...";
        low.CalculateButton.text = "Calculate";
        low.BackButton.text = "Back";
        low.Result.text = "You should eat:\n0Carbs";
        low.Result.fontSize = 29;
        low.NoticeResult.text = "Remember that this is an aproximation and the program doesn't know if you practised sport or just eaten or etc. Please make sure the calculations are the same the ones you usually make.";
        low.WrongInput.text = "Wrong Input\nTry again!!!";
        low.MissingInfo.text = "Missing Information\nTry again!!!";
        low.DrSuggestion.text = "Your Glucose Level is too Low\nCall a doctor!!!\nAnd follow his instructions";

        //info panel
        info.Title.text = "Πληροφορίες";
        info.Content.text = "- Οι πληροφορίες σας δεν συλλέγονται πουθενά και η εφαρμογή έχει πρόσβαση μόνο στην ώρα των συσκευών σας.\n- Αυτή δεν είναι μια εφαρμογή 100 % Acuarte, είναι απλώς μια προσέγγιση για εσάς και μια βοήθεια για υπολογισμούς.\n- σημειώστε ότι Δεν φταίνε οι προγραμματιστές που μπορεί να αυξηθεί η HbA1c σας.\n- Ο προγραμματιστής έφτιαξε αυτήν την εφαρμογή διαβάζοντας για τον διαβήτη, μιλώντας με γιατρούς γι' αυτό και έχει επίσης διαβήτη.\n- Αυτή η εφαρμογή έχει δοκιμαστεί από τρία άτομα με διαβήτη.";
        info.BackButton.text = "Πίσω";
        info.Content.fontSize = 24;

        //ratio panel
        ratio.Title.text = "User Information";
        ratio.WeightText.text = "Body weight\n(kg or lbs)";
        ratio.UI_1.text = "(units)";
        ratio.UI_2.text = ratio.UI_1.text;
        ratio.UI_3.text = ratio.UI_1.text;
        ratio.UI_4.text = ratio.UI_1.text;
        ratio.Breakfest.text = "Breakfest insulin Dose: UI / 10Carbs";
        ratio.Lunch.text = "Lunch insulin Dose: UI / 10Carbs";
        ratio.Dinner.text = "Dinner insulin Dose: UI / 10Carbs";
        ratio.GlucoseLevel.text = "Change Glucose\nlevel unit";
        ratio.CorrectionBolus.text = "Enter your correction Bolus ";
        ratio.Carbs1.text = "10\nCarbs";
        ratio.Carbs2.text = ratio.Carbs1.text;
        ratio.Carbs3.text = ratio.Carbs1.text;
        ratio.CancelButton.text = "Cancel";
        ratio.ConfirmButton.text = "Confirm";
        ratio.ConfirmButton.fontSize = 25;

        //languages panel
        lang.Title.text = "Change Language";
        lang.BackButton.text = "Back";
    }

    //_______________________________________________________________________________________________________________________________________
    //_______________________________________________________________________________________________________________________________________

    public void Romana()
    {
        PlayerPrefs.SetString("language", "romana");

        //main panel
        main.Title.text = "Calculator\npentru\nDiabetici";
        main.Section1.text = "Calculati insulina pentru:";
        main.EatButton.text = "Carbohidrati mâncati";
        main.HighButton.text = "Hyperglicemie";
        main.Section2.text = "Cât să mâncati pentru:";
        main.LowButton.text = "Hipoglicemie";
        main.Section3.text = "Schimbati raportul dintre insulină si HC";
        main.ChangeButton.text = "Schimbati";
        main.MoreInfo.text = "Informatii";
        main.CloseButton.text = "Închideti";

        //high panel
        high.Title.text = "Micsorati Glicemia Dvs";
        high.PlaceHolderHigh.text = "(glicemia actuală...)";
        high.PlaceHolderNormal.text = "(glicemia normală...)";
        high.CalculateButton.text = "Calculati";
        high.BackButton.text = "Înapoi";
        high.Result.text = "0UI";
        high.NoticeResult.text = "Aceasta este o aproximare cu formula:\n1 UI scade 30\nmg / dl";
        high.WrongInput.text = "Intrare gresită\nReîncercati!!!";
        high.MissingInfo.text = "Lipsă Informatii\nReîncercati!!!";
        high.DrSuggestion.text = "Glicemia DVS. este prea mare\nContactati un Doctor!!!\nSi urmăritii instructiunile.";

        //eat panel
        eat.Title.text = "Insulină necesară\npentru HC mâncati";
        eat.PlaceHolderActualGlucoseLevel.text = "Glicemia actuala:";
        eat.GlLevel.text = "(Glicemie)";
        eat.PlaceHolderCarbsEaten.text = "HC mâncati:";
        eat.CarbsEaten.text = "(HC)";
        eat.CalculateButton.text = "Calculati";
        eat.BackButton.text = "Înapoi";
        eat.Result.text = "0UI";
        eat.NoticeResult.text = "Rezultatul este bazat pe doza tipică de insulină/10 carbohidrati, dar daca ati practicat sport, aceasta este doar o aprox.";
        eat.NoticeResult.fontSize = 25;
        eat.MissingInfo.text = "Lipsă Informatii\nReîncercati!!!";
        eat.Attention.text = "N-ar trebui să mâncati cu glicemia peste 150 mg/DL (8.3 mmol/L)";

        //low panel
        low.Title.text = "Cresteti\nGlicemia Dvs\nla normal";
        low.PlaceHolderLow.text = "(glicemia actuală...)";
        low.PlaceHolderNormal.text = "(glicemia normală...)";
        low.CalculateButton.text = "Calculati";
        low.BackButton.text = "Înapoi";
        low.Result.text = "Ar trebui să mâcati:\n0HC";
        low.Result.fontSize = 24;
        low.NoticeResult.text = "Atentie! aceasta este doar o aproximatie si programul nu stie dacă abia ați practicat sport sau înainte ati mai luat o gustare. Vă rog să vă asigurați că rezultatul seamană cu cel utilizat de dvs. de regulă.";
        low.WrongInput.text = "Intrare gresită\nReîncercati!!!";
        low.MissingInfo.text = "Lipsă Informatii\nReîncercati!!!";
        low.DrSuggestion.text = "Glicemia dvs. este prea mica.\nContactati un doctor!!!\nSi urmăritii instructiunile.";

        //info panel
        info.Title.text = "Informatii";
        info.Content.text = " -	Your Information isn't collected anywhere and the app accesses only the time of your devices.\n- This is not a 100 % Accuarte app, it is just an aproximation for you and a helper for calculations.\n- note that it isn't the developers fault that your HbA1c may rise.\n- The developer made this app by reading about diabetes, talking to doctors about it and he has also diabetes.\n- This app has been tested by three people with diabetes.";
        info.Content.text = " -	Informatile dvs. nu sunt colectate niciunde si aplicatia accesează doar ora dispozitivului dvs.\n- Rezultatele nu sunt 100% exacte, iar acestea sunt numai niste aproximări sau ajutoare pentru dvs.\n- Antentie! nu este vina dezvoltatorului că nivelul dvs de HbA1c ar putea creste.\n- Dezvoltatorul este bine informat despre diabet, a vorbit cu doctori si el însusi are diabet.\n- Aplicatia a fost testată de trei persoane cu diabet.";
        info.BackButton.text = "Înapoi";
        info.Content.fontSize = 24;

        //ratio panel
        ratio.Title.text = "Informatii\nUtilizator";
        ratio.WeightText.text = "Masa corporală\n(kg or lbs)";
        ratio.UI_1.text = "(UI)";
        ratio.UI_2.text = ratio.UI_1.text;
        ratio.UI_3.text = ratio.UI_1.text;
        ratio.UI_4.text = ratio.UI_1.text;
        ratio.Breakfest.text = "Dosa de insulină de dimineată: UI/10HC";
        ratio.Lunch.text = "Dosa de insulină de prânz: UI/10HC";
        ratio.Dinner.text = "Dosa de insulină de seară: UI/10HC";
        ratio.GlucoseLevel.text = "Unitatea de măsurare\na glicemiei";
        ratio.CorrectionBolus.text = "Inserati bolusul de corectie:";
        ratio.Carbs1.text = "10\nHC";
        ratio.Carbs2.text = ratio.Carbs1.text;
        ratio.Carbs3.text = ratio.Carbs1.text;
        ratio.CancelButton.text = "Anulare";
        ratio.ConfirmButton.text = "Confirmare";
        ratio.ConfirmButton.fontSize = 21 ;

        //languages panel
        lang.Title.text = "Schimbă Limba";
        lang.BackButton.text = "Înapoi";
    }

    //_______________________________________________________________________________________________________________________________________
    //_______________________________________________________________________________________________________________________________________
    
    public void French()
    {
        PlayerPrefs.SetString("language", "french");

        //main panel
        main.Title.text = "Calculatrice\npour\nDiabétiques";
        main.Section1.text = "Calculez l'insuline pour:";
        main.EatButton.text = "Glucides consommés";
        main.HighButton.text = "Glycémie élevée";
        main.Section2.text = "Combien manger pour:";
        main.LowButton.text = "Glycémie bassee";
        main.Section3.text = "Changez l'insulin en rapport de glucides:";
        main.ChangeButton.text = "Changez";
        main.MoreInfo.text = "Plus d'info";
        main.CloseButton.text = "Fermez";

        //high panel
        high.Title.text = "Rétrogradez votre taux de glycémie";
        high.PlaceHolderHigh.text = "Entrez votre\nglycémie élevée...";
        high.PlaceHolderNormal.text = "Entrez la glycémie\nidéale...";
        high.CalculateButton.text = "Calculez";
        high.BackButton.text = "Arrière";
        high.Result.text = "0UI";
        high.NoticeResult.text = "C'est une approximation basée sur la formule:\n1 l'unité s'abaisse 30\nmg / dl";
        high.WrongInput.text = "Mauvaise entrée\nRéessayez!!!";
        high.MissingInfo.text = "Information manquante\nRéessayez!!!";
        high.DrSuggestion.text = "Votre taux de glycémie est trop élevé\nAppelez un docteur!!!\nEt suivez ses instructions";

        //eat panel
        eat.Title.text = "L'insulin pour GLUCIDES\nCalculatrice";
        eat.PlaceHolderActualGlucoseLevel.text = "Votre Taux De Glycémie:";
        eat.GlLevel.text = "(taux de glycémie)";
        eat.PlaceHolderCarbsEaten.text = "Glucides à manger:";
        eat.CarbsEaten.text = "(Glucides)";
        eat.CalculateButton.text = "Calculez";
        eat.BackButton.text = "Arrière";
        eat.Result.text = "0UI";
        eat.NoticeResult.text = "Le résultat est basée sur votre dose d'insulin typique pour 10 Glucides, mais si vous avez fait du sport avant manger, c'est juste une approximation.";
        eat.NoticeResult.fontSize = 22;
        eat.MissingInfo.text = "Information manquante\nRéessayez!!!";
        eat.Attention.text = "*vous ne devriez manger si le taux de glycémie est supérieur à 150 mg/DL (8.3 mmol/L)";

        //low panel
        low.Title.text = "Augmentez votre taux de glycémie";
        low.PlaceHolderLow.text = "Entrez votre\nglycémie bassee...";
        low.PlaceHolderNormal.text = "Entrez lq glycémie\nidéale...";
        low.CalculateButton.text = "Calculez";
        low.BackButton.text = "Arrière";
        low.Result.text = "Vous devriez manger:\n0Glucides";
        low.Result.fontSize = 24;
        low.NoticeResult.text = "Rappelez-vous que c'est une approximation and que le programme ne sait pas si vous venez de manger ou de faire du sport etc. Veuillez vous assurer que le calcul est le meme que celui habietuellement.";
        low.WrongInput.text = "Mauvaise entrée\nRéessayez!!!";
        low.MissingInfo.text = "Information manquante\nRéessayez!!!";
        low.DrSuggestion.text = "Votre taux de glycémie est trop bas\nAppelez un docteur!!!\nEt suivez ses instructions";

        //info panel
        info.Title.text = "Information";
        info.Content.text = " -	Votre informations ne sont pas collectées nulle part et l'application accède uniquement à l'heure de vos appareils.\n- Ce n'est pas une application 100% précise, c'est juste une approximation pour vous et un assistant pour le calcul.\n- Notez que ce n'est pas la faute du développeur si votre taux de glycémie augmente.\n- Le développeur a fait cette application en lisant sur le diabète, en parlant de ça avec les docteurs et lui-meme est diabétique.\n- Cette application a été testée par trois diabétiques.";
        info.BackButton.text = "Arrière";
        info.Content.fontSize = 21;

        //ratio panel
        ratio.Title.text = "Informations de l'utilisateur";
        ratio.WeightText.text = "Poids\n(kg or lbs)";
        ratio.UI_1.text = "unités";
        ratio.UI_2.text = ratio.UI_1.text;
        ratio.UI_3.text = ratio.UI_1.text;
        ratio.UI_4.text = ratio.UI_1.text;
        ratio.Breakfest.text = "Petit déjeuner dose d'insuline: UI/10 Carbs";
        ratio.Lunch.text = "Déjeuner dose d'insuline: UI/10 Carbs";
        ratio.Dinner.text = "Dîner dose d'insuline: UI/10Carbs";
        ratio.GlucoseLevel.text = "Changez l'unité de taux\nde glycémie";
        ratio.CorrectionBolus.text = "Entrez votre bolus de correction";
        ratio.Carbs1.text = "10\nGlucides";
        ratio.Carbs2.text = ratio.Carbs1.text;
        ratio.Carbs3.text = ratio.Carbs1.text;
        ratio.CancelButton.text = "Annuler";
        ratio.ConfirmButton.text = "Confirmer";
        ratio.ConfirmButton.fontSize = 25;

        //languages panel
        lang.Title.text = "Changez la langue";
        lang.BackButton.text = "Arrière";
    }

    //_______________________________________________________________________________________________________________________________________
    //_______________________________________________________________________________________________________________________________________

    public void Deutsch()
    {
        PlayerPrefs.SetString("language", "deutsch");

        //main panel
        main.Title.text = "Computer\nfür\nDiabetiker";
        main.Section1.text = "Insulin berechnen für:";
        main.EatButton.text = "Kohlenhydrate gegessen";
        main.HighButton.text = "Hyperglykämie";
        main.Section2.text = "Wie viel zu essen für:";
        main.LowButton.text = "Hypoglykämie";
        main.Section3.text = "Ändern Sie das Verhältnis von Insulin zu HC";
        main.ChangeButton.text = "Abändern";
        main.MoreInfo.text = "Informationen";
        main.CloseButton.text = "Schließen";

        //high panel
        high.Title.text = "Reduzieren Sie Ihren Blutzucker";
        high.PlaceHolderHigh.text = "(aktueller Blutzucker ...)";
        high.PlaceHolderNormal.text = "(normaler Blutzucker...)";
        high.CalculateButton.text = "Rechnen";
        high.BackButton.text = "Zurück";
        high.Result.text = "0UI";
        high.NoticeResult.text = "Diese ist eine Annäherung mit der Formel:\n1 UI scade 30\nmg / dl";
        high.WrongInput.text = "Falsche Eingabe\nBitte wieder versuchen!!!";
        high.MissingInfo.text = "Informationsmangel\nBitte wieder versuchen!!!";
        high.DrSuggestion.text = "Ihr Blutzucker ist zu hoch\nWenden Sie sich an einen Arzt!!!\nUnd folgen Sie den Anweisungen.";

        //eat panel
        eat.Title.text = "Insulin erforderlich\nfür HC essen";
        eat.PlaceHolderActualGlucoseLevel.text = "Aktueller Blutzucker:";
        eat.GlLevel.text = "(Blutzucker)";
        eat.PlaceHolderCarbsEaten.text = "HC gegessen:";
        eat.CarbsEaten.text = "(HC)";
        eat.CalculateButton.text = "Rechnen";
        eat.BackButton.text = "Zurück";
        eat.Result.text = "0UI";
        eat.NoticeResult.text = "Das Ergebnis basiert auf der typischen Dosis Insulin / 10 Kohlenhydrate, aber wenn Sie Sport getrieben haben, ist dies nur eine Annäherung.";
        eat.NoticeResult.fontSize = 22;
        eat.MissingInfo.text = "Falsche Eingabe\nBitte wieder versuchen!!!";
        eat.Attention.text = "Bei Blutzuckerwerten über 150 mg/DL (8,3 mmol/L) sollten Sie nicht essen";

        //low panel
        low.Title.text = "Erhöhen Sie\nIhren Blutzucker\nauf den Normalwert";
        low.PlaceHolderLow.text = "(aktueller Blutzucker ...)";
        low.PlaceHolderNormal.text = "(normaler Blutzucker...)";
        low.CalculateButton.text = "Rechnen";
        low.BackButton.text = "Zurück";
        low.Result.text = "Du solltest essen:\n0HC";
        low.Result.fontSize = 22;
        low.NoticeResult.fontSize = 16;
        low.NoticeResult.text = "Vorsichtig! Dies ist nur eine Annäherung und das Programm weiß nicht, ob Sie gerade Sport getrieben oder vorher einen Snack gegessen haben. Bitte stellen Sie sicher, dass das Ergebnis dem entspricht, das Sie normalerweise verwenden.";
        low.WrongInput.text = "Falsche Eingabe\nBitte wieder versuchen!!!";
        low.MissingInfo.text = "Informationsmangel\nBitte wieder versuchen!!!";
        low.DrSuggestion.text = "Ihr Blutzucker ist zu niedrig.\nWenden Sie sich an einen Arzt !!!\nUnd folgen Sie den Anweisungen.";

        //info panel
        info.Title.text = "Informatii";
        info.Content.text = " -	Informatile dvs. nu sunt colectate niciunde si aplicatia accesează doar ora dispozitivului dvs.\n- Rezultatele nu sunt 100% exacte, iar acestea sunt numai niste aproximări sau ajutoare pentru dvs.\n- Antentie! nu este vina dezvoltatorului că nivelul dvs de HbA1c ar putea creste.\n- Dezvoltatorul este bine informat despre diabet, a vorbit cu doctori si el însusi are diabet.\n- Aplicatia a fost testată de trei persoane cu diabet.";
        info.BackButton.text = "Zurück";
        info.Content.fontSize = 24;

        //ratio panel
        ratio.Title.text = "Informationen\nzum Patienten";
        ratio.WeightText.text = "Körpermasse\n(kg or lbs)";
        ratio.UI_1.text = "(UI)";
        ratio.UI_2.text = ratio.UI_1.text;
        ratio.UI_3.text = ratio.UI_1.text;
        ratio.UI_4.text = ratio.UI_1.text;
        ratio.Breakfest.text = "Morgendliche Insulindosis: UI /10HC";
        ratio.Lunch.text = "Insulindosis zum Mittagessen: UI/10HC";
        ratio.Dinner.text = "Abendliche Insulindosis: UI /10HC";
        ratio.GlucoseLevel.text = "Blutzuckereinheit";
        ratio.CorrectionBolus.text = "Geben Sie den Korrekturbolus ein:";
        ratio.Carbs1.text = "10\nHC";
        ratio.Carbs2.text = ratio.Carbs1.text;
        ratio.Carbs3.text = ratio.Carbs1.text;
        ratio.CancelButton.text = "Abbrechen";
        ratio.ConfirmButton.text = "Bestätigen";
        ratio.ConfirmButton.fontSize = 21;

        //languages panel
        lang.Title.text = "Sprache verändern";
        lang.BackButton.text = "Zurück";
    }
}
