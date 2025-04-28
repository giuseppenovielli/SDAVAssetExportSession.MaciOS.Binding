// AVVISO: questa funzionalità è deprecata. Usare invece la cartella "Riferimenti nativi".
// Fare clic con il pulsante destro del mouse sulla cartella "Riferimenti nativi", selezionare "Aggiungi riferimento nativo",
// e quindi selezionare la libreria statica o il framework che si vuole associare.
//
// Dopo aver aggiunto la libreria statica o il framework, fare clic con il pulsante destro del mouse sulla libreria o
// e selezionare "Proprietà" per modificare i valori LinkWith.

using ObjCRuntime;

[assembly: LinkWith ("libSDAVAssetExportSession.a", SmartLink = true, ForceLoad = true)]
