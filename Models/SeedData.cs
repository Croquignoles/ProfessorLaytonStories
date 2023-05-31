namespace ProfessorLayton.Models;
using ProfessorLayton.Data;

public class SeedData
{
    public static void init()
    {
        using (var context = new ProfessorLaytonContext())
        {
            // Look for existing content
            if (context.Games.Any())
            {
                return;   // DB already filled
            }

            var game1 = new Game
            {
                Title = "Professeur Layton et l'étrange village",
                ReleaseDate = DateTime.Parse("2008-11-7"),
                Description = "Le professeur Layton et son assistant Luke se rendent au petit village de Saint-Mystère à la demande de Dahlia Reinhold, deuxième femme de feu le baron Reinhold, qui souhaite leur aide pour résoudre une énigme laissée par son défunt époux. Le baron avait écrit dans son testament que quiconque retrouverait la Pomme d'Or, cachée dans le village, hériterait de toute sa fortune. Les deux investigateurs parviennent aux abords de la ville et constatent rapidement que la majorité des habitants est passionnée d'énigmes et de casse-tête en tout genre, desquels le professeur et le jeune garçon sont aussi férus. Ils peuvent également voir au loin une mystérieuse tour située au centre du village...",
                UrlImage1 = "0101.jpg",
                UrlImage2 = "0102.jpg",
                UrlImage3 = "0103.jpg",

            };
            var game2 = new Game
            {
                Title = "Professeur Layton et la boîte de Pandore",
                ReleaseDate = DateTime.Parse("2009-9-29"),
                Description = "Le professeur Hershel Layton et son apprenti, Luke, reçoivent une lettre d'Andrew Schrader, savant respecté, mentor et ami du professeur, qui contient des informations sur le coffret céleste, communément appelé la ''Boîte de Pandore''. Inquiets, Layton et Luke décident d'aller voir Andrew, mais une fois sur place ces derniers le trouvent inconscient et le coffret a disparu. Dans le bureau du savant, Layton et Luke trouvent un ticket pour le Molentary Express et une photo déchirée. Ils décident de prendre le train pour retrouver la Boîte de Pandore. Une fois arrivés à Dropstone, les deux héros découvrent une destination mystère du Molentary Express : Folsense, une ville fantôme.",
                UrlImage1 = "0201.jpg",
                UrlImage2 = "0202.jpg",
                UrlImage3 = "0203.jpg",
            };
            var game3 = new Game
            {
                Title = "Professeur Layton et le destin perdu",
                ReleaseDate = DateTime.Parse("2010-10-22"),
                Description = "Le Professeur Layton et Luke reçoivent une lettre leur demandant de l'aide envoyée par... Luke, 10 ans après. Le professeur - croyant à une farce de son jeune assistant - n'y accordera pas d'importance mais part enquêter une semaine plus tard après la disparition de Bill Hawks, le premier ministre de Londres, dans l'explosion d'une hypothétique machine à remonter le temps. La lettre lui disant de se rendre à une horlogerie, Layton et Luke découvriront une horloge qui les propulsera 10 ans dans le futur. Retrouvez un Luke adulte mais aussi Flora, l'inspecteur Chelmey et Don Paolo dans 165 nouvelles énigmes et casse-têtes où l'adversaire de Hershel Layton sera Hershel Layton lui-même, son futur puis son passé.",
                UrlImage1 = "0301.jpg",
                UrlImage2 = "0302.jpg",
                UrlImage3 = "0303.jpg",            
            };

            context.Games.AddRange(
                // add games
                game1,
                game2,
                game3
            );
            var musicEnigmas= new Music
            {
                Name="Professeur Layton - Puzzle",
                URL="https://www.youtube.com/watch?v=AVcNPWhdrRw",
                Games = {game1,game2, game3},
            };
            var musicGame1=new Music
            {
                Name="Professeur Layton - L'étrange Vilage",
                URL="https://www.youtube.com/watch?v=vtica2GaE4A",
                Games = {game1},

                
            };
            var musicGame2=new Music
            {
                Name="Professeur Layton - Le destin perdu",
                URL="https://www.youtube.com/watch?v=-7BF3X0qb6g",
                Games = {game3},
            };
            context.Musics.AddRange(musicEnigmas,musicGame1,musicGame2);
            
            context.Characters.AddRange(

                 //Add characters
                 new Character
                 {
                     FirstName = "Hershel",
                     LastName = "Layton",
                     IsBadGuy = false,
                     Description = "Le Professeur Hershel Layton est le protagoniste principal de la série des Professeur Layton. C'est un professeur d'archéologie à l'université de Gressenheller à Londres. Il est mondialement renommé pour sa faculté à résoudre des énigmes. Il voyage avec son apprenti auto-proclamé, Luke Triton. Layton est un parfait gentleman, passionné d'énigmes et grand amateur de thé. Son ami Randall Ascott lui a donné le goût de l'aventure et lui a permis de devenir l'éminent professeur d'archéologie qu'il est aujourd'hui. Il avoue un certain manque d'organisation: son bureau est sens dessus-dessous. Il n'est pas dans ses habitudes de se départir de son fameux haut de forme. Pourtant, à la fin de l'épisode du Destin Perdu, il ôte son chapeau et nous laisse découvrir un épi sur le côté gauche de sa tête. Comme il le montre dans chacun des jeux, il est brave, intelligent et sportif. Il est également calme et poli.",
                     UrlImage1 = "Hershel1.jpg",
                     UrlImage2 = "Hershel2.jpg",
                     UrlImage3 = "Hershel3.jpg",
                     Games = {game1,game2, game3},

                 },

                new Character
                {
                    FirstName = "Luke",
                    LastName = "Triton",
                    IsBadGuy = false,
                    Description = "Luke Triton est l'assistant du Professeur Layton. Luke est un jeune garçon doté d'une grande maturité pour son âge. Il a la capacité de s'entretenir avec des animaux et est déjà expert en résolution d'énigmes, très probablement en raison du fait qu'il est toujours avec son mentor, le Professeur Layton. Il voudrait devenir un véritable gentleman comme lui et a honte lorsqu'il le reprend sur ses bonnes manières. Comme la plupart des enfants de son âge, il lui arrive d'être insolent. Il a toujours faim et a un appétit d'ogre.",
                    UrlImage1 = "Luke1.jpg",
                    UrlImage2 = "Luke2.jpg",
                    Games = {game1,game2, game3},

                },

                new Character
                {
                    FirstName = "Paolo",
                    IsBadGuy = true,
                    Description = "Don paolo est l'un des antagonistes principaux de la saga. Ancien élève du Dr. Shrader tout comme Layton. Il devient maléfique suite a un chagrin d'amour, que lui a causé Claire,la petite amie de Hershel. C'est un maitre du déguisement, il se déguise plusieurs fois en certains personnages et on ne le sait pas avant que Layton le démasque. Il a malgré tout des élans de gentillesses assez suprnenants par moment, et n'est donc pas complètement méchant dans le fond.",
                    UrlImage1 = "Paolo1.jpg",
                    UrlImage2 = "Paolo2.jpg",
                    Games = {game1,game2, game3},
                    
                },

                new Character
                {
                    FirstName = "Vladimir",
                    LastName = "Van Herzen",
                    IsBadGuy = true,
                    Description = "Vladimir est le duc de Folsense et vit dans le château des Van Herzen. Il se fait passer pour un vampire pour que personne ne s'approche du château. Il aimait Sophia, dont il fût séparé à cause d'un problème en ville. Celle-ci partit pour protéger leur enfant. Lorsque le Professeur Layton est enfermé dans son manoir et qu'il tente de s'échapper avec Katia Herzen, Vladimir s'interpose et croit voir Sophia car elle lui ressemble beaucoup. Il entre dans une colère noire car il pense que Sophia était partie parce qu'elle aimait quelqu'un d'autre alors qu'en vérité, elle était partie pour protéger leur enfant.Lorsque qu'il apprend que Sophia est morte, il détruis le château dans lequel il vivait. Il est le grand-père de Katia.Vladimir est un personnage très complexe: Avant le désastre à Folsense, il était modeste et poli (étant élevé comme un aristocrate). Il détestait être haut dans la société, ce qui était une preuve de son humilité. Être avec Sophia le rendait très heureux; il était dévasté lorsqu'elle l'a laissé et ne pas savoir pourquoi le contrariait encore plus. Depuis, il est devenu plus retiré et il a commencé a ressentir de la haine envers tout le reste. Même s'il n'a jamais vraiment pardonné Sophia après qu'elle soit partie, il était plus heureux de connaître la véritable raison de son départ et s'est comporté tel un gentleman.",
                    UrlImage1 = "Vladimir1.jpg",
                    UrlImage2 = "Vladimir2.jpg",
                    UrlImage3 = "Vladimir3.jpg",
                    Games = {game2},
                    
                }

            );
            

                //Add enigmas
                var enigma1 = new Enigma
                {
                    Name = "Combien de bonbons ?",
                    Content = "Trois garçons sont en train de discuter du nombre de bonbons qu'ils ont.\nA : c'est B qui en a le plus.\nB : si C m'en donne un, j'en aurai deux fois plus que A.\n C : Il vaudrait mieux que B m'en donne deux.\n Comme ça, on en aurait tous autant !\n\n Combien de bonbons y a-t-il en tout ?",
                    Game = game1

                };
                var enigma2 = new Enigma
                {
                    Name = "Champion de golf",
                    Content = "Un golfeur professionnel possède un don incroyable. Il est capable de réaliser des putts de distance toujours égale. Pourtant, bizarrement, ses coups lui permettent uniquement de couvrir les distances suivantes : 3,5,7 et 11m.\nNotre golfeur est sur le green, à 20m du trou. Combien de coups lui faut-il au minimum pour mettre la balle dans le trou ?\n\nAttention si la balle est lancée sur une distance plus longue que celle menant au trou, elle continuera sa course sans tomber dans le trou.",
                    Game = game2


                };
                var enigma3 = new Enigma
                {
                    Name = "Fieffé menteur",
                    Content = "L'une de ces personnes a cassé une fenêtre. On les interroge dans l'ordre suivant pour démasquer le coupable :\n\nA dit: 'Ce n'est pas moi.'\nB ajoute:'A dit la vérité.'\nC déclare: 'De toute évidence, D ment.'\nD affirme:'Jamais je ne ferais une chose pareille.'\n\n L'une de ces déclarations paraît un peu suspecte. L'auteur de cette déclaration est le coupable. Pouvez-vous l'identifier ?",
                    Game = game3

                };
            context.AddRange(
                enigma1,
                enigma2,
                enigma3
            );
            
            
            var solution1 = new Solution 
            {
                Content = "La réponse est 9. \nCar A possède 3 bonbons, B en a 5 et C n'en a qu'un seul." ,
                Enigma = enigma1,
                urlImg = "0167.jpg ",
            };           
            
            var solution2 = new Solution 
            {
                Content = "Si notre ami golfeur réalise deux coups en diagonale, comme illustré ci-dessus, ces deux coups seront suffisants pour mettre la balle dans le trou. Il n’a jamais été dit qu’il était interdit d’utiliser toute la surface du green, n’est-ce pas ?",
                Enigma = enigma2,
                urlImg = "0237.jpg",
            };

            var solution3 = new Solution 
            {
                Content = "C a cassé la fenêtre."  + "\nIl accuse D de mentir avant même que cette dernière ait pu témoigner.",
                Enigma = enigma3,
                urlImg = "0364.jpg",
            };

            var hint11 = new Hint 
            {
                Content = "Si B donnait deux bonbons à C, tout le monde en aurait le même nombre. Cela veut donc dire que B a deux bonbons de plus que A et quatre bonbons de plus que C.",
                Enigma = enigma1,
                HintRange = HintRange.firstStep,
            };

            var hint12 = new Hint 
            {
                Content = "Comme indiqué dans l'indice précédent, B a deux bonbons de plus que A. Si C donnait un bonbon à B, B en aurait deux fois plus que A. Grâce à ces deux faits, vous devriez savoir combien de bonbons A possède.",
                Enigma = enigma1,
                HintRange = HintRange.advancedHint,
            };

            var hint13 = new Hint 
            {
                Content = "A possède trois bonbons. Vous devriez maintenant savoir combien de bonbons possède B, étant donné qu'il en a deux de plus que A!",
                Enigma = enigma1,
                HintRange = HintRange.obviousSolution,
            };

            var hint31 = new Hint 
            {
                Content = "Lisez les déclarations dans l'ordre, et prêtez une attention particulière à ce que dit chaque personne.",
                Enigma = enigma3,
                HintRange = HintRange.firstStep,
            };

            var hint32 = new Hint 
            {
                Content = "Relisez les déclarations dans l'ordre de A à D. L'une d'entre elles est assez suspecte...",
                Enigma = enigma3,
                HintRange = HintRange.advancedHint,
            };


            var hint33 = new Hint 
            {
                Content = "Le coupable est la personne qui a parlé un peu trop vite. Si les déclarations étaient faites dans l'ordre inverse, de D à A, le coupable aurait pu s'en sortir.",
                Enigma = enigma3,
                HintRange = HintRange.obviousSolution,
            };
            
            var hint21=new Hint{
                Content="La solution n'implique pas que le golfeur dépasse le trou.",
                Enigma=enigma2,
                HintRange=HintRange.firstStep
            };
            var hint22=new Hint{
                Content="Il n'y a aucune raison pour que notre ami golfeur doive frapper chaque putt directement vers le trou.\n Il pourrait peut-être placer sa balle dans une meilleure position en effectuant un coup en diagonale.",
                Enigma=enigma2,
                HintRange=HintRange.advancedHint
            };
            var hint23=new Hint{
                Content="Imaginez que le golfeur effectue un coup en diagonale par rapport au trou. S'il frappe la balle à exactement 11 mètres et qu'il oriente son coup de manière à ce que son premier putt le place exactement à mi-chemin entre sa position de départ et le trou...Vous voyez où je veux en venir ?",
                Enigma=enigma2,
                HintRange=HintRange.obviousSolution
            };
            context.Hints.AddRange(
                hint11,
                hint12,
                hint13,
                hint21,
                hint22,
                hint23,
                hint31,
                hint32,
                hint33
            );

            context.Solutions.AddRange(
                solution1,
                solution2,
                solution3
            );

            context.SaveChanges();
        }
    }
}