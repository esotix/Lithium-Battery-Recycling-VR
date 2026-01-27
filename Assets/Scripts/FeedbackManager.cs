using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string FeedbackDisplayed;
    public int place;
    public int randomDisplay;
    [SerializeField] public FeedbackUI feedbackUI;


    string[] feedbacksNikon = new string[]
    {
    "Placement incorrect : ce type de batterie peut provoquer un court-circuit dans ce conteneur.",
    "Erreur de tri : risque d’échauffement lié à une incompatibilité de stockage.",
    "Tri non conforme : cette batterie doit être traitée dans un circuit spécifique.",
    "Mauvais emplacement : possibilité de fuite d’électrolyte détectée.",
    "Erreur environnementale : ce tri empêche un recyclage adapté des cellules lithium.",
    "Stockage inapproprié : risque de détérioration prématurée des composants internes.",
    "Non-respect des consignes : danger de contact entre pôles conducteurs.",
    "Tri incorrect : ce type de batterie ne supporte pas ce mode de compression.",
    "Erreur de procédure : séparation des matériaux impossible dans ce circuit.",
    "Mauvais tri : contamination potentielle de la filière de recyclage.",
    "Placement dangereux : risque de perforation lors de la manipulation automatique.",
    "Non-conformité : ce type de batterie exige un conditionnement spécifique.",
    "Erreur de sécurité : incompatibilité avec les batteries présentes dans ce lot.",
    "Tri inadéquat : dégradation chimique accélérée possible.",
    "Mauvaise orientation : perte de matériaux recyclables de haute valeur."
    };


    string[] feedbacksVolt = new string[]
    {
    "Erreur critique : ce type de batterie présente un risque d’incendie dans ce circuit.",
    "Tri incorrect : non-respect des normes de sécurité industrielle.",
    "Placement inadapté : surcharge thermique possible lors du stockage.",
    "Non-conformité réglementaire : batterie orientée vers un traitement interdit.",
    "Mauvais tri : dispersion de composants toxiques possible dans la chaîne de recyclage.",
    "Erreur de procédure : ce type de batterie nécessite une isolation renforcée.",
    "Placement dangereux : risque de réaction chimique avec les matériaux voisins.",
    "Non-respect des protocoles : danger de dégagement gazeux inflammable.",
    "Tri interdit : incompatibilité avec le système de neutralisation.",
    "Erreur environnementale : pollution possible par métaux lourds.",
    "Mauvais stockage : instabilité électrique détectée.",
    "Non-conformité : ce lot ne peut être traité dans cette filière.",
    "Erreur de sécurité : risque de rupture de cellule sous contrainte mécanique.",
    "Tri inapproprié : échauffement progressif non contrôlé.",
    "Placement incorrect : défaut de confinement des substances actives.",
    "Mauvaise orientation : perte de traçabilité réglementaire.",
    "Erreur critique : ce type de batterie exige un traitement prioritaire.",
    "Tri dangereux : accumulation d’énergie non sécurisée.",
    "Non-respect des normes : procédure de décharge non appliquée.",
    "Erreur majeure : instabilité thermique détectée."
    };


    string[] feedbacksCar = new string[]
    {
    "Erreur majeure : ce type de batterie peut provoquer une réaction thermique dangereuse.",
    "Placement interdit : risque élevé d’explosion dans ce circuit de traitement.",
    "Non-conformité grave : cette batterie doit suivre un protocole spécialisé.",
    "Tri dangereux : tension incompatible avec l’infrastructure actuelle.",
    "Impact environnemental critique : mauvais traitement des matériaux à haute toxicité.",
    "Erreur de sécurité : énergie résiduelle non neutralisée.",
    "Placement inadapté : risque de défaillance catastrophique du module.",
    "Non-respect des procédures haute tension.",
    "Tri interdit : danger immédiat pour les opérateurs.",
    "Erreur critique : ce type de batterie nécessite un confinement renforcé.",
    "Mauvais tri : fuite thermique possible entre modules.",
    "Non-conformité réglementaire sévère : protocole véhicule électrique ignoré.",
    "Erreur environnementale majeure : dispersion de lithium et de solvants organiques.",
    "Placement dangereux : incompatibilité avec les systèmes d’extinction automatique.",
    "Tri incorrect : dégradation irréversible des matériaux stratégiques.",
    "Erreur de procédure : démontage préalable obligatoire non effectué.",
    "Non-respect des consignes : risque d’arc électrique.",
    "Mauvais stockage : instabilité structurelle du pack détectée.",
    "Tri critique : danger de propagation thermique entre cellules.",
    "Erreur majeure : batterie haute énergie orientée vers une filière non sécurisée.",
    "Non-conformité extrême : traitement interdit par la réglementation.",
    "Placement dangereux : risque de perforation de module.",
    "Erreur système : surcharge énergétique non contrôlée.",
    "Tri inacceptable : menace directe pour la chaîne de traitement.",
    "Erreur fatale : protocole de mise en sécurité absent."
    };

    public void displayFeedBack(int numeroList)
    {
        if (numeroList == 1)
        {
            randomDisplay = UnityEngine.Random.Range(0, feedbacksNikon.Length);
            
            FeedbackDisplayed = feedbacksNikon[randomDisplay];
        }
        else if (numeroList == 2)
        {
            randomDisplay = UnityEngine.Random.Range(0, feedbacksVolt.Length);

            FeedbackDisplayed = feedbacksVolt[randomDisplay];
        }
        else if(numeroList == 3) 
        {
            randomDisplay = UnityEngine.Random.Range(0, feedbacksCar.Length);

            FeedbackDisplayed = feedbacksCar[randomDisplay];
        }
        feedbackUI.ShowFeedback(FeedbackDisplayed);
    }
}
