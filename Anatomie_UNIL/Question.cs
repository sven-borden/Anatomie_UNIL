using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anatomie_UNIL
{
    class Question
    {
        #region musclesDef
        /// <summary>
        /// Données concernant le membre supérieur
        /// </summary>
        public static string[,] epauleAnterieur = new string[5, 4] {
            {"muscle grand pectoral", "Clavicule(1/2 méd), sternum, 4 à 6 cartilages costaux, gaine du muscle droit de l'abdomen", "Crète du tubercule majeur de l'humérus", "N. pectoraux"},
            {"muscle petit pectoral", "Côtes 3-5","Processus coracoïde","N. pectoraux"},
            {"muscle subclavier","Cartilage 1ère côte","Face inférieure de la clavicule","N. pectoraux"},
            {"muscle sterno-cléido.mastoïdien","Sternum et clavicule","Processus mastoïde et ligne nuchale sup.","N. accessoire et plexus cervical"},
            {"muscle deltoïde","Clavicule (tier lat.), acromion et épine de la scapula","Tubérosité deltoïdienne de l'humérus","N. axillaire"}
        };
        public static string[,] epaulePosterieur = new string[11, 4]{
            {"muscle supra-épineux", "Fosse supra-épineuse", "Facette sup. du tubercule majeur de l'humérus", "N. supra-scapulaire"},
            {"muscle infra-épineux", "Fosse infra-épineuse", "Facette moy. du tubercule majeur de l'humérus", "N. supra-scapulaire"},
            {"muscle petit rond", "Bord lateral sup. de la scapula", "Facette inf. du tubercule majeur de l'humérus", "N. axillaire"},
            {"muscle grand rond", "Bord inf. et lat. de la scapula", "Crète du tubercule mineur de l'humérus", "N. subscapulaire"},
            {"muscle subscapulaire", "Fosse subscapulaire", "Tubercule mineur de l'humérus", "N. subscapulaire"},
            {"muscle grand dorsal", "Processus épineux T7 à L5, aponévrose lombaire, crète iliaque partie post., angle inf. de la scapula, sacrum, côtes 10-12", "Crète du tubercule mineur de l'humérus", "N. thoraco dorsal"},
            {"muscle dentelé antérieur", "9-10 digitations sur les côtes 1-9", "Angle sup., bord méd ant., angle inf. de la scapula", "N. thoracique long"},
            {"muscle petit rhomboïde", "Processus épineux C6 et C7", "Bord méd. de la scapula, au-dessus de l'épine scapulaire", "N. dorsal de la scapula"},
            {"muscle grand rhomboïde", "Processus épineux T1 à T4", "Bord méd. de la scapula au-dessous de l'épine scapulaire", "N. dorsal de la scapula"},
            {"muscle élévateur de la scapula", "Processus transverse, C1-C4", "Angle sup. de la scapula", "N. dorsal de la scapula"},
            {"muscle trapèze", "Protubérance occipitale ext. ligne nuchale sup., lig. nuchal sup., processus épineux C7-T12", "Clavicule (1/3 lat.), acromion et épine de la scapula", "N. accessoire et plexus cervical"},
        };
        public static string[,] bras = new string[8, 4]{
            {"muscle biceps brachial chef long", "Tubercule supra-glénoïdal", "Tubérosité du radius et expansion aponévrotique bicipitale", "N. musculo-cutané"},
            {"muscle biceps brachial chef court", "Processus coracoïde", "Tubérosité du radius et expansion aponévrotique bicipitale", "N. musculo-cutané"},
            {"muscle coraco-brachial", "Processus coracoïde", "1/3 moyen face méd. humérus", "N. musculo-cutané"},
            {"muscle brachial", "2/3 inf. face ant. de l'humérus", "tubérosité de l'ulna", "N. musculo-cutané"},
            {"muscle triceps brachial chef long", "Tubercule infra-glénoïdal", "Olécrâne de l'ulna", "N. radial"},
            {"muscle triceps brachial chef méd. (vaste interne)", "face post. de l'humérus côté méd. et distal du sillon du n. radial", "Olécrâne de l'ulna", "N. radial"},
            {"muscle triceps brachial chef lat. (vaste externe)", "face post. de l'humérus côté lat. et prox du sillon du n.radial", "Olécrâne de l'ulna", "N. radial"},
            {"muscle anconé", "Epicondyle lat. de l'humérus", "Olécrâne de l'ulna", "N. radial"},
        };

        public static string[,] avantBrasAntérieur = new string[8, 4]{
            {"muscle rond pronateur", "Epicondyle méd. de l'humérus et processus coronoïde de l'ulna", "Milieu, face lat. du radius", "N. médian"},
            {"muscle fléchisseur radial du carpe", "Epicondyle méd. de l'humérus", "Base 2e et 3e métacarpiens (palmaire)", "N. médian"},
            {"muscle long palmaire", "Epicondyle méd. de l'humérus", "Aponévrose palmaire", "N. médian"},
            {"muscle fléchisseur ulnaire du carpe", "Epicondyle méd., olécrâne, et 2/3 post. prox. de l'ulna", "Os pisiforme, os hamatum, 5e métacarpien", "N. ulnaire"},
            {"muscle fléchisseur superficiel des doigts", "Epicondyle méd. de l'humérus, processus coronoïde de l'ulna, face ant. du radius", "Phalanges moyennees, doigts 2-5", "N. médian"},
            {"muscle fléchisseur profond des doigts", "3/4 prox. de face ant. et méd. de l'ulna, membrane inteross.", "Base des phalanges distales des doigts 2-5", "N. médian & ulnaire"},
            {"muscle long fléchisseur du pouce", "Face ant. du radius au-dessous de la tubérosité radiale, memb. inteross.", "Base de la phalange distale du pouce", "N. médian"},
            {"muscle carré pronateur", "1/4 distal de face ant. de l'ulna", "1/4 distal de face ant. du radius", "N. médian"},
        };

        public static string[,] avantBrasPostérieur = new string[11, 4]{
            {"muscle brachio-radial", "Septum intermusculaire lat. et bord lat. de l'humérus", "Processus styloïde du radius", "N. radial"},
            {"muscle long extenseur radial du carpe", "septum intermusculaire lat. et bord lat. de l'humérus", "Base 2e métacarpien post.", "N. radial"},
            {"muscle court extenseur radial du carpe", "septum intermusculaire lat. et bord lat. de l'humérus", "Base 3e métacarpien post.", "N. radial"},
            {"muscle extenseur des doigts", "Epicondyle lat. de l'humérus", "Aponévrose dorsales, phalanges des doigts 2-5", "N. radial"},
            {"muscle extenseur propre du 5e doigt", "Epicondyle lat. de l'humérus", "Aponévrose dorsale du 5e doigt", "N. radial"},
            {"muscle extenseur ulnaire du carpe", "Epicondyle lat. humérus, ulna, et lig. collatéral radial", "Base du 5e métacrpien, face post.", "N. radial"},
            {"muscle supinateur", "Crète ulnaire du muscle supinateur, épicondyle lat. de l'humérus, lig. collatéral radial", "Face lat. et bord ant. du radius", "N. radial"},
            {"muscle long abducteur, du pouce", "Face post. memb. inteross., faces adj. de l'ulna et du radius", "Base du 1er métacarpien", "N. radial"},
            {"muscle court extenseur du pouce", "Face post. du radius et de la memb. inteross.", "Base phalange prox. du pouce", "N. radial"},
            {"muscle long extenseur du pouce", "Face post de l'ulna et de la memb. inteross.", "Base phalange dist. du pouce", "N. radial"},
            {"muscle extenseur de l'index", "Tiers inf. de face post. de l'ulna, memb. inteross.", "Aponévrose dorsale de l'index", "N. radial"},
        };

        public static string[,] main = new string[13, 4]{
            {"muscle court palmaire", "Aponévrose palmaire", "Peau du bord ulnaire de la main", "N. ulnaire"},
            {"muscle abducteur du 5e doigt", "Os pisi, lig. piso-hamatum et rétinaculum des fléchisseurs", "Base phalange prox. du 5e doigt et aponévrose dorsale", "N. ulnaire"},
            {"muscle court fléchisseur du 5e doigt", "Rétinaculum des fléchisseurs, crochet (hamulus) de l'hamatum", "Base phalange prox. du 5e doigt, avec m. abd. du 5e doigt", "N. ulnaire"},
            {"muscle opposant du 5e doigt", "Rétinaculum des fléchisseurs et hamulus du scaphoïde", "Tête et corps, bord ulnaire, du 5e métacarpien", "N. ulnaire"},
            {"muscle court abducteur du pouce", "Rétinaculum des fléchisseurs et tubercule du scaphoïde", "Sésamoïde lat. et phalange prox. du pouce", "N. ulnaire"},
            {"muscle court fléchisseur du pouce chef superficiel", "Rétinaculum des fléchisseurs", "Sésamoïde lat. et bord radial", "N. médian"},
            {"muscle court fléchisseur du pouce chef profond", "Trapèze, trapézoïde, capitatum, base 1er métacarpien", "Phalange prox. du pouce", "N. ulnaire"},
            {"muscle adducteur du pouce chef transverse", "Face ant. 3e métacarpien", "Sésamoïde méd et bord ulnaire", "N. ulnaire"},
            {"muscle adducteur du pouce chef oblique", "Trapézoïde et capitatum", "Phalange prox. du pouce", "N. ulnaire"},
            {"muscle opposant du pouce", "Tubercule du trapèze, rétinaculum des fléchisseurs", "Bord lat. du 1er métacarpien", "N. ulnaire"},
            {"muscle interosseux palmaires", "Bases des métacarpiens 2, 4, 5", "Aponévrose dorsale doigts 2, 4, 5", "N. ulnaire"},
            {"muscle interosseux dorsaux", "2 chefs sur métacarpiens adjacents 1-5", "Aponévroses dorsales doigts 2-4", "N. ulnaire"},
            {"muscles lombricaux", "Tendons du m. fléchisseur profond des doigts", "Face radiale aponévroses dorsales et capsules art. métacarpo-phalangiennes des doigts 2-5", "N. ulnaire"},
        };

        /// <summary>
        /// Données des muscles de la nuque, du cou, du dos, du thorax et de l'abdomen
        /// </summary>
        /// 
        public static string[,] nuqueEtCou = new string[10, 4] {
            {"muscle trapèze", "Processus épineux C7-T12, lig. nuchale, protubérance occipitale ext., ligne nuchale sup.", "Epine de la scapula, acromion, clavicule (1/3 lat.)", "N. accessoire (XI) et plexus cervical"},
            {"muscle sterno-cléido-mastoïdien", "Sternum et clavicule", "Processus mastoïde, ligne nuchale sup. de l'os occipital", "N. accessoire (XI) et plexus cervical"},
            {"muscle élévateur de la scapula", "Tubercule post. des processus transverses de C1-C4", "Angle supérieur de la scapula", "N. dorsal de la scapula"},
            {"muscle splénius de la tête", "Processus épineux C4-T3", "Moitié lat. de la ligne nuchale sup., processus mastoïde de l'os temporal", "Branche post. des nn. spinaux"},
            {"muscle splénius du cou", "Processus épineux T3-T5", "Tubercule post. des processuss transverses de C1 et C2", "Branche post. des nn. spinaux"},
            {"muscle semi-épineux de la tête", "Processus transvverses C4-T6", "Entre les lignes nuchales sup. et inf. de l'os occipital", "Branche post. des nn. spinaux"},
            {"muscle grand droit postérieur de la tête", "Processus épineux de l'axis (C2)", "Tiers moyen de la ligne nuchale inf.", "Branche post. du n. C1 (suboccipital)"},
            {"muscle petit droit postérieur de la tête", "Tubercule post. de l'atlas (C1)", "Tiers médial de la ligne nuchale inf.", "Branche post. du n. C1 (suboccipital)"},
            {"muscle oblique supérieur de la tête", "Processus transverse de l'atlas", "Aire au-dessus du muscle grand droit post. de la tête", "Branche post. du n. C1 (suboccipital)"},
            {"muscle oblique inférieur de la tête", "Processus épineux de l'axis", "Processus transverse de l'atlas", "Branche post. du n. C1 (suboccipital)"},
        };

        public static string[,] dos = new string[19, 4] {
            {"muscle grand dorsal", "Processus épineux T7-L5, aponévrose lombaire, crête iliaque, sacrum", "Crête du tubercule mineur de l'humérus", "N. thoraco-dorsal"},
            {"muscle grand rhomboïde", "Processus épineux T1-T4", "Bord méd. de la scapula, au-dessous de l'épine", "N. dorsal de la scapula"},
            {"muscle petit rhomboïde", "Processus épineux C6-C7", "Bord méd. de la scapula, au-dessus de l'épine", "N. dorsal de la scapula"},
            {"muscle dentelé postérieur et supérieur", "Processus épineux C6-T2", "De la 2e à la 6e côte", "N. intercostaux"},
            {"muscle dentelé postérieur et inférieur", "Processus épineux T11-L2", "De la 9e à la 12e côte", "N. intercostaux"},
            {"muscle ilio-costal du cou", "Angle des côtes supérieures", "Processus transverses C3-C5", "Branche post. nn. spinaux"},
            {"muscle ilio-costal du thorax", "Méd. angle des 6 côtes inférieures", "Les 6 côtes supérieures", "Branche post. nn. spinaux"},
            {"muscle ilio-costal des lombes", "Crête iliaque", "Angles des 6 côtes inférieures", "Branche post. nn. spinaux"},
            {"muscle longissimus de la tête", "Processus transverse C3-T1", "Processus mastoïde", "Branche post. nn. spinaux"},
            {"muscle longissimus du cou", "Processus transverses T1-T6", "Processus transverses C2-C7", "Branche post. nn. spinaux"},
            {"muscle longissimus du thorax", "Crête iliaque, processus épineux L1-4, processus mamillaires L1-L2, processus transverses T7-T12", "Processus costiformes L1-L5, angles des côtes 2-12, processus transverses T1-T12", "Branche post. nn. spinaux"},
            {"muscle épineux du thorax", "Processus épineux T11-L2", "Processus épineux T2-T11", "Branche post. nn. spinaux"},
            {"muscle épineux du cou", "Processus épineux C6-T2", "Processus épineux C2-C4", "Branche post. nn. spinaux"},
            {"muscle épineux de la tête", "Inconstant", "Inconstant", "Branche post. nn. spinaux"},
            {"muscle semi-épineux du cou", "Processus transverses T1-T6", "Processus épineux C2-C5", "Branche post. nn. spinaux"},
            {"muscle semi-épineux du thorax", "Processus transverses T7-T12", "Processus épineux C6-T6", "Branche post. nn. spinaux"},
            {"muscles rotateurs et multifides", "Processus transverse", "Processus épineux", "Branche post. nn. spinaux"},
            {"muscle inter-épineux", "Processus épineux (cervical et lombaire)", "Processus épineux adjacent", "Branche post. nn. spinaux"},
            {"muscle inter-transversaire", "Processus transverse (cervical et lombaire", "Processus transverse adjacent", "Branche post. nn. spinaux"},
        };

        public static string[,] thoraxEtAbdomen = new string[9, 4]{
            {"muscles intercostaux externes", "Dirigés obliquement en bas et en avant", "Dirigés obliquement en bas et en avant", "NN. intercostaux"},
            {"muscles intercostaux internes", "Dirigés obliquement en bas et en arrière", "Dirigés obliquement en bas et en arrière", "NN. intercostaux"},
            {"muscles intercostaux intimes", "Plan le plus profond des muscles intercostaux internes", "Plan le plus profond des muscles intercostaux internes", "NN. intercostaux"},
            {"muscle transverse du thorax", "Face interne paroi ventrale du sternum", "Cartilages costaux 2-6", "NN. intercostaux"},
            {"muscle droit de l'abdomen", "Cartilage côtes 5-7, processus xyphoïde", "Symphyse et crête pubiennes", "NN. intercostaux et n. subcostal"},
            {"muscle pyramidal", "Pubis", "Ligne blanche", "NN. subcostal"},
            {"muscle oblique externe", "Face ext. côtes 5-12. crête iliaque, fascia thoraco-lombaire, lig. inguinal", "Gaine du muscle droit de l'abdomen et ligne blanche", "NN. intercostaux et n. subcostal"},
            {"muscle oblique interne", "Crête iliaque, fascia thoraco-lombaire, lig. inguinal", "Côtes 10-12, gaine du muscle droit de l'abdomen et ligne blanche", "NN. intercostaux et n. subcostal"},
            {"muscle transverse de l'abdomen", "Face int. côtes 7-12, crête iliaque, fascia thoraco-lombaire, lig. inguinal", "Gain du muscle droit de l'abdomen et ligne blanche", "NN. intercostaux et n. subcostal"},
        };

        ///Hanche et jambe
        public static string[,] hanche = new string[13, 4]{
            {"muscle ilio-psoas iliaque", "Fosse iliaque", "Petit trochanter", "Plexus lombaire et n. fémoral (crural)"},
            {"muscle ilio-psoas psoas", "Corps et disques intervert. L1-L4", "Petit trochanter", "Plexus lombaire et n. fémoral (crural)"},
            {"muscle carré des lombes", "Crête iliaque", "12e côte processus costiforme L1-L4", "N. subcostal et plexus lombaire"},
            {"muscle tenseur du fascia lata", "Côté lat. de  l'épine iliaque antéro-supérieure", "Tractus ilio-tibial, lat. à la tubérosité externe du tibia", "N. glutéal supérieur"},
            {"muscle grand fessier", "Face post. et ext. de l'ilium, sacrum, coccyx, lig. sacro-tubéral profond : aile iliaque", "Tractus ilio-tibial, tubérosité glutéale du fémur", "N. glutéal supérieur"},
            {"muscle moyen fessier", "Face ext. de l'ilium, entre lignes glutéales post. et ant.", "Grand trochanter", "N. glutéal supérieur"},
            {"muscle petit fessier", "Face ext. de l'ilium, entre lignes glutéales ant. et inf.", "Grand trochanter", "N. glutéal supérieur"},
            {"muscle piriforme", "Plusieurs digitations sur la face pelvienne du sacrum en dehors des trous sacrés ant. et bord de la grande échancrure sciatique", "Face médiale de la pointe du grand trochanter", "Plexus sacré"},
            {"muscle obturateur interne", "Face int. de la membrane obturatrice et cadre osseux voisin de l'os coxal", "Fosse trochantérique du fémur", "N. du m. obturateur interne"},
            {"muscle jumeaux supérieur", "Epine sciatique", "Fosse trochantérique du fémur", "N. glutéal inférieur et plexus sacré"},
            {"muscle jumeau inférieur", "Tubérosité ischiatique", "Fosse trochantérique du fémur", "N. glutéal inférieur et plexus sacré"},
            {"muscle carré fémoral", "Tubérosité ischiatique", "Crête intertrochantérique", "N. glutéal inférieur et plexus sacré"},
            {"muscle obturateur externe", "Face ext. de la membrane obturatrice et cadre osseux voisin de l'os coxal", "Fosse trochantérique du fémur", "N. obturateur"},
        };

        //Muscle de la cuisse
        public static string[,] cuisse = new string[16, 4]{
            {"muscle sartorius (coururier)", "Epine iliaque antéro supérieure", "Face médiale de la tubérosité tibiale (patte d'oie)", "N. fémoral (crural)"},
            {"muscle quadriceps droit fémoral", "Epine iliaque antéro-inférieure, bord supérieur de l'acétabulum", "Tendon du quadriceps, sur la patella et par le lig. patellaire sur la tubérosité tibiale", "N. fémoral (crural)"},
            {"muscle quadriceps vaste intermédiaire", "Face antérieure du fémur", "Tubérosité tibiale", "N. fémoral (crural)"},
            {"muscle quadriceps vaste médial", "Lèvre méd. de la ligne âpre du fémur partie dist. ligne intertrochantérique", "Tubérosité tibiale", "N. fémoral (crural)"},
            {"muscle quadriceps vaste latéral", "Face latérale du grand trochanter et lèvre lat. de la ligne âpre du fémur", "Tubérosité tibiale", "N. fémoral (crural)"},
            {"muscle pectiné", "Pecten du pubis", "Ligne pectinéale au-dessous du petit trochanter", "N. fémoral (crural), et branche antérieure du n. obturateur"},
            {"muscle court petit adducteur", "Moitié inf. de la branche descendante du pubis", "Tiers supérieur de la lèvre méd. de la ligne âpre du fémur", "Branche antérieure du n. obturateur"},
            {"muscle long moyen adducteur", "Inf. près de la symphyse pubienne", "Tiers moyen de la lèvre méd. de la ligne âpre du fémur", "Branche antérieure du n. obturateur"},
            {"muscle grand adducteur faisceau supérieur", "Branche de l'ischion", "Lèvre méd. de la ligne âpre du fémur", "N. obturateur"},
            {"muscle grand adducteur faisceau moyen", "Branche de l'ischion", "Lèvre méd. de la ligne âpre du fémur", "N. obturateur"},
            {"muscle grand adducteur faisceau inférieur", "Branche de l'ischion jusqu'à la tubérosité ischiatique", "Tubercule du grand adducteur sur l'épicondyle méd. du fémur", "N. tibial"},
            {"muscle gracile (droit interne)", "Branche descendante du pubis méd. au m. grand adducteur", "Face méd. de la tubérosité du tibia (patte d'oie)", "Branche antérieure du n. obturateur"},
            {"muscle biceps fémoral chef long", "Tubérosité ischiatique", "Tête de la fibula", "N. sciatique (n. tibial; n. sciatique poplité int.)"},
            {"muscle biceps fémoral chef court", "Tieres moyen de la lèvre lat. de la ligne âpre du fémur et de la cloison intermusculaire lat. de la cuisse", "Tête de la fibula", "N. sciatique (n. fibulaire commun, n. sciatique poplité ext."},
            {"muscle semi-tendineux", "Tubérosité ischiatique", "Face médiale de la tubérosité du tibia (patte d'oie)", "N. tibial"},
            {"muscle semi-membraneux", "Tubérosité ischiatique", "Condyle méd. du tibia, et ligament poplité oblique", "N. tibial"},
        };

        //Muscles de la jambe
        public static string[,] jambe = new string[14, 4]{
            {"muscle tibial antérieur", "Face lat. du tibia, memb. inteross. fascia crural", "Face plantaire, cunéiforme médial, et métatarsien 1", "N. fibulaire profond"},
            {"muscle long extenseur des orteils", "Condyle lat. du tibia, tête et crête de la fibula, memb. inteross.", "Divisé en quatre tendons au niveau de la cheville, aponévrose dorsale des orteils 2-5", "N. fibulaire profond"},
            {"muscle 3e fibulaire (péronier antérieur)", "Division du muscle long extenseur", "Base du métatarsien 5", "N. fibulaire profond"},
            {"muscle long extenseur de l'hallux", "Face méd. de la fibula (péroné) et memb. inteross.", "Phalange distale de l'hallux", "N. fibulaire profond"},
            {"muscle long fibulaire", "Fibula et fascia crural", "Traverse la plante du pied, tubercule du métatarsien 1 et cunéiforme médial (1er)", "N. fibulaire superficiel"},
            {"muscle court fibulaire", "2/3 dist. face latérale de la fibula", "Tubercule du métatarsien 5", "N. fibulaire superficiel"},
            {"muscle triceps sural - gastrocnémien chef médial", "Côté proximal du condyle fémoral médial", "Tendon calcanéen (d'Achille), tubérosité postérieur du calcanéus", "N. tibial"},
            {"muscle triceps sural - gastrocnémien chef latéral", "Côté proximal du condyle fémoral latéral", "Tendon calcanéen (d'Achille), tubérosité postérieur du calcanéus", "N. tibial"},
            {"muscle triceps sural - soléaire", "Extrémité proximale de la fibula et du tibia", "Tendon calcanéen (d'Achille), tubérosité postérieur du calcanéus", "N. tibial"},
            {"muscle plantaire (grêle)", "Au-dessus du condyle fémoral latéral avec le m. grastrocnémien latéral", "Tendon calcanéen (d'Achille), tubérosité postérieur du calcanéus", "N. tibial"},
            {"muscle poplité", "Condyle latéral du fémur", "Face postérieure du tibia", "N. tibial"},
            {"muscle tibial postérieur", "Memb. interosseuses et zones adjacentes du tibia et de la fibula", "Os naviculaire, cunéiformes, cuboïde et métatarsiens 2-4", "N. tibial"},
            {"muscle long fléchisseur des orteils", "Face postérieure du tibia", "Quatre tendons terminaux, sur les phalanges distales des orteils 2-5", "N. tibial"},
            {"muscle long fléchisseur de l'hallux", "2/3 inf. face postérieure de la fibula, memb. interrosseuse et septum intermusculaire latéral", "Base de la phalange distale de l'hallux", "N. tibial"},
        };

        //Muscle court du pied
        public static string[,] pied = new string[14, 4]{
            {"muscle court extenseur des orteils", "Calcanéus (face dorsale)", "Aponévroses dorsales des orteils 2-4", "N. fibulaire profond"},
            {"muscle court extenseur de l'hallux", "Calcanéus (face dorsale)", "Face dorsale de la phalange proximale de l'hallux", "N. fibulaire profond"},
            {"muscle abducteur de l'hallux", "Processus méd. de la tubérosité du calcanéus", "Sésamoïde méd. et base de la phalange prox. de l'hallux", "N. plantaire médial"},
            {"muscle court fléchisseur de l'hallux", "Os cuboïde et lig. plantaire", "Deux chefs, sur les deux sésamoïdes et la base de la phalange prox. de l'hallux", "N. plantaire médial"},
            {"muscle adducteur de l'hallux chef oblique", "Base des métatarsiens 2-4, du 3e cunéiforme (lat.) et du cuboïde", "Os sésamoïde lat. & phalange prox. de l'hallux", "N. plantaire latéral"},
            {"muscle adducteur de l'hallux chef transverse", "capsule art. métatarsophalangiennes des orteils 3-5", "Os sésamoïde latéral", "N. plantaire latéral"},
            {"muscle abducteur du 5e orteil", "Tubérosité ext. du calcanéus et aponévrose plantaire", "Côté lat. base phalange prox. du petit orteil", "N. plantaire latéral"},
            {"muscle court fléchisseur du 5e orteil", "Base du 5e métatarsien", "Base phalange prox. du petit orteil", "N. plantaire latéral"},
            {"muscle opposant du 5e orteil", "Lig. plantaire long et gaine du m. long fibulaire", "Bord lat. du 5e métatarsien", "N. plantaire latéral"},
            {"muscle court fléchisseur des orteils", "Tubérosité post. du calcanéus et aponévrose plantaire", "Par des tendons divisés à la phalange moyenne des orteils 2-5", "N. plantaire latéral"},
            {"muscle carré plantaire", "Bord méd. et lat. du calcanéus", "Bord lat. du tendon du m. long fléchisseur des orteils", "N. plantaire latéral"},
            {"muscles lombricaux", "Côté méd. des tendons du m. long fléchisseur des orteils", "Bord. méd des phalanges prox. des orteils 2.5", "N. plantaire latéral"},
            {"muscles interosseux plantaires", "Par 1 seul chef sur les métatarsiens 2-5", "Base des phalanges prox. des orteils 3-5", "N. plantaire latéral"},
            {"muscles interosseux dorsaux", "Par 2 chefs sur les métatarsiens adjacents 1-5", "Aponévrose dorsale des phalanges prox. des orteils 2-4", "N. plantaire latéral"},
        };
        #endregion

        private string[] questions;
        private int _membre = 1;
        Random rand;
        WriteTo settings;

        public Question(int membre)
        {
            _membre = membre;
            rand = new Random();
            settings = new WriteTo();
            questions = new string[5];
        }

        //return question[5] containing the question and the 4 possible answer, the position 1 is reserved for the right answer
        //ENTRY POINT
        public string[] getQuestion(List<string> listeQuestion)
        {
            switch(_membre)
            {
                case 1: return SetQuestion(SetQuestionType(), listeQuestion);
                case 2: return SetQuestion(SetQuestionType(), listeQuestion);
                case 3: return SetQuestion(SetQuestionType(), listeQuestion);
                case 4: return CaseAll(listeQuestion);
            }

            return questions;
        }

        private string[] SetQuestion(int questionType, List<string> liste)
        {
            string[] question = new string[5];

            question = GenQuestion(questionType, liste);
            return question;
        }

        private string[] GenQuestion(int questionType, List<string> liste)
        {
            switch(_membre)
            {
                case 1: return GenQuestionSup(questionType, liste);
                case 2: return GenQuestionInf(questionType, liste);
                case 3: return GenQuestionTrc(questionType, liste);
                default: return GenQuestionSup(questionType, liste);
            }
        }
        
        private string[] GenQuestionSup(int type, List<string> liste)
        {
            
            switch (Random(1, 6))
            {
                case 1: return GenEpauleAnt(type, liste);
                case 2: return GenEpaulePost(type, liste);
                case 3: return GenBras(type, liste);
                case 4: return GenAvantBrasAnt(type, liste);
                case 5: return GenAvantBrasPost(type, liste);
                case 6: return GenMain(type, liste);
                default: return GenEpauleAnt(type, liste);
            }
        }


        #region genSup
        private string[] GenEpauleAnt(int type, List<string> liste)
        {
            
            int length = 5;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, epauleAnterieur[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = epauleAnterieur[answerNb, type];

            for(int i = 0; i < 10; i++)
            {
                question[2] = epauleAnterieur[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for(int i = 0; i < 10; i++)
            {
                question[3] = epauleAnterieur[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = epauleAnterieur[Random(0, length - 1), type];
                if (question[4] != question[3] &&question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenEpaulePost(int type, List<string> liste)
        {
            
            int length = 11;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, epaulePosterieur[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = epaulePosterieur[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = epaulePosterieur[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = epaulePosterieur[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = epaulePosterieur[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenBras(int type, List<string> liste)
        {
            
            int length = 8;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, bras[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = bras[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = bras[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = bras[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = bras[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenAvantBrasAnt(int type, List<string> liste)
        {
            
            int length = 8;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, avantBrasAntérieur[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = avantBrasAntérieur[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = avantBrasAntérieur[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = avantBrasAntérieur[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = avantBrasAntérieur[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenAvantBrasPost(int type, List<string> liste)
        {
            
            int length = 8;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, avantBrasPostérieur[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = avantBrasPostérieur[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = avantBrasPostérieur[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = avantBrasPostérieur[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = avantBrasPostérieur[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenMain(int type, List<string> liste)
        {
            
            int length = 8;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, main[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = main[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = main[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = main[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = main[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }
        #endregion

        private string[] GenQuestionInf(int type, List<string> liste)
        {
            switch(Random(1, 4))
            {
                case 1: return GenHanche(type, liste);
                case 2: return GenCuisse(type, liste);
                case 3: return GenJambe(type, liste);
                case 4: return GenPied(type, liste);
                default: return GenHanche(type, liste);
            }
        }

        #region genInf
        private string[] GenHanche(int type, List<string> liste)
        {
            int length = 13;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, hanche[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = hanche[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = hanche[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = hanche[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = hanche[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }
        private string[] GenCuisse(int type, List<string> liste)
        {
            int length = 16;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, cuisse[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = cuisse[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = cuisse[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = cuisse[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = cuisse[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenJambe(int type, List<string> liste)
        {
            int length = 14;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, jambe[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = jambe[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = jambe[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = jambe[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = jambe[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenPied(int type, List<string> liste)
        {
            int length = 14;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, pied[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = pied[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = pied[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = pied[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = pied[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }
        #endregion

        private string[] GenQuestionTrc(int type, List<string> liste)
        {
            switch(Random(1, 3))
            {
                case 1: return GenNuque(type, liste);
                case 2: return GenDos(type, liste);
                case 3: return GenThorax(type, liste);
                default: return GenNuque(type, liste);
            }
        }

        #region genTrc
        private string[] GenNuque(int type, List<string> liste)
        {
            int length = 10;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, nuqueEtCou[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = nuqueEtCou[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = nuqueEtCou[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = nuqueEtCou[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = nuqueEtCou[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenDos(int type, List<string> liste)
        {
            int length = 19;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, dos[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = dos[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = dos[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = dos[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = dos[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }

        private string[] GenThorax(int type, List<string> liste)
        {
            int length = 9;
            int answerNb = Random(0, length - 1);
            string[] question = new string[5];
            for (int i = 0; i < 10; i++)
            {
                question[0] = RequireQuestion(type, thoraxEtAbdomen[answerNb, 0]);
                if (liste.Contains(question[0]) == false)
                    break;
            }

            question[1] = thoraxEtAbdomen[answerNb, type];

            for (int i = 0; i < 10; i++)
            {
                question[2] = thoraxEtAbdomen[Random(0, length - 1), type];
                if (question[2] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[3] = thoraxEtAbdomen[Random(0, length - 1), type];
                if (question[3] != question[2] && question[3] != question[1])
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                question[4] = thoraxEtAbdomen[Random(0, length - 1), type];
                if (question[4] != question[3] && question[4] != question[2] && question[4] != question[1])
                    break;
            }

            return question;
        }
        #endregion

        private string[] CaseAll(List<string> liste)
        {
            string[] tmp = new string[5];
            _membre = Random(1, 3);
            tmp = getQuestion(liste);
            _membre = 4;
            return tmp;
        }
        
        private int SetQuestionType()
        {
            int type = 1;
            for(int i = 0; i < 10; i++)
            {
                type = Random(1, 3);
                if (type == 1 && settings.isInsertion == true)
                    break;
                if (type == 2 && settings.isTerminaison == true)
                    break;
                if (type == 3 && settings.isInnevervation == true)
                    break;
                if (type == 4 && settings.isMouvement == true)
                    break;
            }
            return type;
        }

        private string RequireQuestion(int type, string muscle)
        {
            if (type == 1)//origine
                return "Quelle est l'origine du " + muscle + "?";
            if (type == 2)//Insertion
                return "Quelle est la terminaison du " + muscle + "?";
            if (type == 3)//innervation
                return "Quelle est l'innervation du " + muscle + "?";
            else
                return "Quelle est l'origine du " + muscle + "?";
        }

        private int Random(int borneInf, int borneSup) { return rand.Next(borneInf, borneSup + 1); }

    }
}
