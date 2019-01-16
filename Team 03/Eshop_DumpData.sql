USE eShop
GO

-------------------- TABLE USERS --------------------------
INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('admin', 'Admin', '1', 'admin1@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'Ha Noi', 'VietNam', GETDATE(), 0, 1, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('user1', 'User', '1', 'user1@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'Washington', 'USA', '2018-11-10', 0, 0, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('user2', 'User', '2', 'user2@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'London', 'England', '2018-12-10', 0, 0, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('user3', 'User', '3', 'user3@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'Liverpool', 'England', '2018-11-10', 0, 0, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('user4', 'User', '4', 'user4@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'Manchester', 'England', '2018-12-10', 0, 0, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('user5', 'User', '5', 'user5@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'Paris', 'France', '2018-10-10', 0, 0, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('user6', 'User', '6', 'user6@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'Paris', 'France', '2018-11-10', 0, 0, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('user7', 'User', '7', 'user7@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'Liverpool', 'England', '2018-12-10', 0, 0, GETDATE(), 1, GETDATE(), 1)
GO
INSERT INTO [dbo].[User] ([Username], [FirstName], [LastName], [Email], [Password], [City], [Country], [SignUpDate], [OrderCount], [Role], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('user8', 'User', '8', 'user8@fsoft.com.vn', 'XFCGRKadqlG5kh+00WZYxg==', 'TP HCM', 'VietNam', '2018-12-10', 0, 0, GETDATE(), 1, GETDATE(), 1)

--------------------- TABLE PRODUCT METADATA ------------------

INSERT INTO [dbo].[Artist] (Name, Born, Country, [Description], CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES ('Vincent Van Gogh', '1853-1890', 'Holland', 'Vincent Willem van Gogh was a Dutch Post-Impressionist painter who is among the most famous and influential figures in the history of Western art. In just over a decade he created about 2,100 artworks, including around 860 oil paintings, most of them in the last two years of his life. They include landscapes, still lifes, portraits and self-portraits, and are characterised by bold colours and dramatic, impulsive and expressive brushwork that contributed to the foundations of modern art. However, he was not commercially successful and his suicide at 37 followed years of mental illness and poverty'
		, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Artist] (Name, Born, Country, [Description], CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES ('Leonardo Da Vinci', '1452–1519', 'Italy', 'Leonardo di ser Piero da Vinci, more commonly Leonardo da Vinci or simply Leonardo, was an Italian polymath of the Renaissance whose areas of interest included invention, painting, sculpting, architecture, science, music, mathematics, engineering, literature, anatomy, geology, astronomy, botany, writing, history, and cartography. He has been variously called the father of palaeontology, ichnology, and architecture, and he is widely considered one of the greatest painters of all time. Sometimes credited with the inventions of the parachute, helicopter, and tank, he epitomised the Renaissance humanist ideal.'
		, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Artist] (Name, Born, Country, [Description], CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES ('Rembrandt', '1606–1669', 'Holland', 'Rembrandt Harmenszoon van Rijn was a Dutch draughtsman, painter and printmaker. An innovative and prolific master in three media, he is generally considered one of the greatest visual artists in the history of art and the most important in Dutch art history. Unlike most Dutch masters of the 17th century, Rembrandt`s works depict a wide range of style and subject matter, from portraits and self-portraits to landscapes, genre scenes, allegorical and historical scenes, biblical and mythological themes as well as animal studies. His contributions to art came in a period of great wealth and cultural achievement that historians call the Dutch Golden Age, when Dutch art (especially Dutch painting), although in many ways antithetical to the Baroque style that dominated Europe, was extremely prolific and innovative, and gave rise to important new genres. Like many artists of the Dutch Golden Age, such as Jan Vermeer of Delft, Rembrandt was also an avid art collector and dealer.'
		, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Artist] (Name, Born, Country, [Description], CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES ('Jan Vermeer', '1632–1675', 'Holland', 'Johannes Vermeer was a Dutch painter who specialized in domestic interior scenes of middle-class life. He was a moderately successful provincial genre painter in his lifetime but evidently was not wealthy, leaving his wife and children in debt at his death, perhaps because he produced relatively few paintings. Vermeer worked slowly and with great care, and frequently used very expensive pigments. He is particularly renowned for his masterly treatment and use of light in his work. Vermeer painted mostly domestic interior scenes. "Almost all his paintings are apparently set in two smallish rooms in his house in Delft; they show the same furniture and decorations in various arrangements and they often portray the same people, mostly women.'
		, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Artist] (Name, Born, Country, [Description], CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES ('Pablo Picasso', '1881–1973', 'Spain', 'Spanish, modern ‘cubist’ painter. Famous works include Guernica and Bird of Peace'
		, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Artist] (Name, Born, Country, [Description], CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES ('Grant DeVolson Wood', '1892–1942', 'USA', 'An American painter best known for his paintings depicting the rural American Midwest, particularly American Gothic (1930), which has become an iconic painting of the 20th century'
		, GETDATE(), 1, GETDATE(), 1)

GO

---------------------------- TABLE PRODUCT ---------------------------
INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Cafe Terrace at Night', 'Café Terrace at Night is an 1888 oil painting by the Dutch artist Vincent van Gogh. It is also known as The Cafe Terrace on the Place du Forum, and, when first exhibited in 1891, was entitled Coffeehouse, in the evening (Café, le soir).</br>Van Gogh painted Café Terrace at Night in Arles, France, in mid-September 1888. The painting is not signed, but described and mentioned by the artist in three letters.</br>Visitors to the site can stand at the northeastern corner of the Place du Forum, where the artist set up his easel. The site was refurbished in 1990 and 1991 to replicate van Gogh`s painting. He looked south towards the artificially lit terrace of the popular coffee house, as well as into the enforced darkness of the rue du Palais which led up to a building structure (to the left, not pictured) and, beyond this structure, the tower of a former church which is now Musée Lapidaire.',
		1, 'Cafe Terrace at Night.jpg', 4500, 12, 5, GETDATE(), 1, GETDATE(), 1)
		
INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Sunflowers', 'Sunflowers (original title, in French: Tournesols) is the name of two series of still life paintings by the Dutch painter Vincent van Gogh. The first series, executed in Paris in 1887, depicts the flowers lying on the ground, while the second set, executed a year later in Arles, shows a bouquet of sunflowers in a vase. In the artist`s mind both sets were linked by the name of his friend Paul Gauguin, who acquired two of the Paris versions. About eight months later van Gogh hoped to welcome and to impress Gauguin again with Sunflowers, now part of the painted Décoration for the Yellow House that he prepared for the guestroom of his home in Arles, where Gauguin was supposed to stay. After Gauguin`s departure, van Gogh imagined the two major versions as wings of the Berceuse Triptych, and finally he included them in his Les XX in Bruxelles exhibit.', 
		1, 'Sunflowers.jpg', 6500, 33, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Self Portrait', 'In 1886 Vincent van Gogh left his native Holland and settled in Paris, where his beloved brother Theo was a dealer in paintings. Van Gogh created at least twenty-four self-portraits during his two-year stay in the energetic French capital. This early example is modest in size and was painted on prepared artist’s board rather than canvas. Its densely dabbed brushwork, which became a hallmark of Van Gogh’s style, reﬂects the artist’s response to Georges Seurat’s revolutionary pointillist technique in A Sunday on La Grande Jatte—1884. But what was for Seurat a method based on the cool objectivity of science became in Van Gogh’s hands an intense emotional language.</br>The surface of the painting dances with particles of color—intense greens, blues, reds, and oranges. Dominating this dazzling array of staccato dots and dashes are the artist’s deep green eyes and the intensity of their gaze. “I prefer painting people’s eyes to cathedrals,” Van Gogh once wrote to Theo. “However solemn and imposing the latter may be—a human soul, be it that of a poor streetwalker, is more interesting to me.” From Paris, Van Gogh traveled to the southern town of Arles for fifteen months. At the time of his death, in 1890, he had actively pursued his art for only five years.', 
		1, 'Self Portrait.jpg', 4100, 72, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Weeping Woman', 'Van Gogh drew a few sorrowful figures and this Weeping Woman Seated on a Basket is one of that. It is done with black lithographic crayon, grey wash, white and grey opaque watercolor, traces of squaring, on watercolor paper. </br>In a letter to friend Van Gogh described his drawing with the sorrowful figures: </br>"It seems to me that a painter has a duty to try to put an idea into his work. I was trying to say this in this print - but I can`t say it as beautifully, as strikingly as reality, of which this is only a dim reflection seen in a dark mirror - that it seems to me that one of the strongest pieces of evidence for the existence of "something on high" in which Millet believed, namely in the existence of a God and an eternity, is the unutterably moving quality that there can be in the expression of an old man like that, without his being aware of it perhaps, as he sits so quietly in the corner of his hearth. At the same time something precious, something noble, that can`t be meant for the worms. ... This is far from all theology - simply the fact that the poorest woodcutter, heath farmer or miner can have moments of emotion and mood that give him a sense of an eternal home that he is close to.', 
		1, 'Weeping Woman.jpg', 6500, 35, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('The Starry Night', 'Widely hailed as Van Gogh`s magnum opus, the painting depicts the view outside his sanatorium room window at night, although it was painted from memory during the day.</br>Starry Night depicts a dreamy interpretation of the artist`s asylum room`s sweeping view of Saint-Rémy-de-Provence. Though Van Gogh revisited this scene in his work on several occasions, "Starry Night" is the only nocturnal study of the view. Thus, in addition to descriptions evident in the myriad of letters he wrote to his brother, Theo, it offers a rare nighttime glimpse into what the artist saw while in isolation. "Through the iron-barred window I can make out a square of wheat in an enclosure," he wrote in May of 1889, "above which in the morning I see the sun rise in its glory." </br>An end-of-the-world cataclysm invades Van Gogh`s Starry Night, one of apocalypse filled with melting aerolites and comets adrift. One has the impression that the artist has expelled his inner conflict onto a canvas. Everything here is brewed in a huge cosmic fusion. The sole exception is the village in the foreground with its architectural elements. Several months after painting Starry Night, Van Gogh wrote: "Why, I say to myself, should the spots of light in the firmament be less accessible to us than the black spots on the map of France?... Just as we take the train to go to Tarascon or Rouen, we take death to go to a star."', 
		1, 'The Starry Night.jpg', 4900, 26, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Mona Lisa', 'The Mona Lisa is a half-length portrait painting by the Italian Renaissance artist Leonardo da Vinci that has been described as "the best known, the most visited, the most written about, the most sung about, the most parodied work of art in the world". The Mona Lisa is also one of the most valuable paintings in the world. It holds the Guinness World Record for the highest known insurance valuation in history at $100 million in 1962, which is worth nearly $800 million in 2017.</br>The painting is thought to be a portrait of Lisa Gherardini, the wife of Francesco del Giocondo, and is in oil on a white Lombardy poplar panel. It had been believed to have been painted between 1503 and 1506; however, Leonardo may have continued working on it as late as 1517. Recent academic work suggests that it would not have been started before 1513. It was acquired by King Francis I of France and is now the property of the French Republic, on permanent display at the Louvre Museum in Paris since 1797.', 
		2, 'Mona Lisa.jpg', 10000, 50, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('The Lady With An Ermine', 'Lady with an Ermine is a painting by Italian artist Leonardo da Vinci from around 1489–1490 and one of Poland national treasures. The portrait subject is Cecilia Gallerani, painted at a time when she was the mistress of Ludovico Sforza, Duke of Milan, and Leonardo was in the Duke service. It is one of only four portraits of women painted by Leonardo, the others being the Mona Lisa, the portrait of Ginevra de Benci, and La belle ferronnière. The painting was purchased in 2016 from the Czartoryski Foundation by the Polish Ministry of Culture and National Heritage for the National Museum in Kraków, and has been on display in the museums main building since 2017.',
		2, 'The Lady With An Ermine.jpg', 3000, 43, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('The Last Supper', 'Depictions of the Last Supper in Christian art have been undertaken by artistic masters for centuries, Leonardo da Vinci`s late 1490s mural painting in Milan, Italy, being the best-known example. The Last Supper is the final meal that, in the Gospel accounts, Jesus shared with his Apostles in Jerusalem before his crucifixion. The Last Supper is commemorated by Christians especially on Maundy Thursday. The Last Supper provides the scriptural basis for the Eucharist, also known as "Holy Communion" or "The Lords Supper".</br>The First Epistle to the Corinthians contains the earliest known mention of the Last Supper. The four canonical Gospels all state that the Last Supper took place towards the end of the week, after Jesuss triumphal entry into Jerusalem and that Jesus and his Apostles shared a meal shortly before Jesus was crucified at the end of that week. During the meal Jesus predicts his betrayal by one of the Apostles present, and foretells that before the next morning, Peter will deny knowing him', 
		2, 'The Last Supper.jpg', 4500, 17, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('The Jewish Bride', 'The Jewish Bride (Dutch: Het Joodse bruidje) is a painting by Rembrandt, painted around 1667.</br>The painting gained its current name in the early 19th century, when an Amsterdam art collector identified the subject as that of a Jewish father bestowing a necklace upon his daughter on her wedding day. This interpretation is no longer accepted, and the identity of the couple is uncertain. The ambiguity is heightened by the lack of anecdotal context, leaving only the central universal theme, that of a couple joined in love. Speculative suggestions as to the couple`s identity have ranged from Rembrandt`s son Titus and his bride, or Amsterdam poet Miguel de Barrios and his wife. Also considered are several couples from the Old Testament, including Abraham and Sarah, Boaz and Ruth, or Isaac and Rebekah, which is supported by a drawing by the artist several years prior.</br>While technical evidence suggests that Rembrandt initially envisioned a larger and more elaborate composition, the placement of his signature at lower left indicates that its current dimensions are not significantly different from those at the time of its completion. According to Rembrandt biographer Christopher White, the completed composition is "one of the greatest expressions of the tender fusion of spiritual and physical love in the history of painting."', 
		3, 'The Jewish Bride.jpg', 5000, 24, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('The Storm on the Sea of Galilee', 'The Storm on the Sea of Galilee is a painting from 1633 by the Dutch Golden Age painter Rembrandt van Rijn that was in the Isabella Stewart Gardner Museum of Boston, Massachusetts, United States, prior to being stolen in 1990. The painting depicts the miracle of Jesus calming the storm on the Sea of Galilee, as depicted in the fourth chapter of the Gospel of Mark in the New Testament of the Christian Bible. It is Rembrandt`s only seascape.</br>On the morning of March 18, 1990, thieves disguised as police officers broke into the museum and stole The Storm on the Sea of Galilee and 12 other works. Although it is considered the biggest art theft in US history and remains unsolved, the museum still displays the paintings empty frames in their original locations.</br>On March 18, 2013, the FBI announced they knew who was responsible for the crime. Criminal analysis has suggested that the heist was committed by an organized crime group. There have been no conclusions made public as the investigation is ongoing.', 
		3, 'The Storm on the Sea of Galilee.jpg', 4500, 10, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('View of Delft', 'View of Delft (Dutch: Gezicht op Delft) is an oil painting by Johannes Vermeer, painted ca. 1660–1661. The painting of the Dutch artist`s hometown is among his most popular, painted at a time when cityscapes were uncommon. It is one of three known paintings of Delft by Vermeer, along with The Little Street and the lost painting House Standing in Delft. The use of pointillism in the work suggests that it postdates The Little Street, and the absence of bells in the tower of the New Church dates it to 1660-1661. Vermeer`s View of Delft has been held in the Dutch Royal Cabinet of Paintings at the Mauritshuis in The Hague since its establishment in 1822.', 
		4, 'View of Delft.jpg', 8000, 41, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('The Old Guitarist', 'Pablo Picasso produced The Old Guitarist, one of his most haunting images, while working in Barcelona. In the paintings of his Blue Period (1901–4), of which this is a prime example, Picasso restricted himself to a cold, monochromatic blue palette; ﬂattened forms; and the emotional, psychological themes of human misery and alienation, which are related to the Symbolist movement and the work of such artists as Edvard Munch. Picasso presented The Old Guitarist as a timeless expression of human suffering.</br>The bent and sightless man holds his large, round guitar close to him; its brown body is the painting’s only shift in color. The elongated, angular figure of the blind musician relates to the artist’s interest in the history of Spanish art and, in particular, the great sixteenth-century artist El Greco. Most personally, however, the image reﬂects the struggling twenty-two-year-old Picasso’s sympathy for the plight of the downtrodden; he knew what it was like to be poor, having been nearly penniless during all of 1902. His works from this time depict the miseries of the destitute, the ill, and the outcasts of society.', 
		5, 'The Old Guitarist.jpg', 4500, 18, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Portrait of Pablo Picasso', 'In 1906 Juan Gris traveled to Paris, where he met Pablo Picasso and Georges Braque and participated in the development of Cubism. Just six years later, Gris too was known as a Cubist and identified by at least one critic as "Picasso’s disciple." Gris’s style draws upon Analytic Cubism—with its deconstruction and simultaneous viewpoint of objects—but is distinguished by a more systematic geometry and crystalline structure. Here he fractured his sitter’s head, neck, and torso into various planes and simple, geometric shapes but organized them within a regulated, compositional structure of diagonals. The artist further ordered the composition of this portrait by limiting his palette to cool blue, brown, and gray tones that, in juxtaposition, appear luminous and produce a gentle undulating rhythm across the surface of the painting.</br>Gris depicted Picasso as a painter, palette in hand. The inscription, "Hommage à Pablo Picasso," at the bottom right of the painting demonstrates Gris’s respect for Picasso as a leader of the artistic circles of Paris and as an innovator of Cubism. At the same time, the inscription helped Gris solidify his own place within the Paris art world when he exhibited the portrait at the Salon des Indépendants in the spring of 1912.', 
		5, 'Portrait of Pablo Picasso.jpg', 7300, 46, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('The Red Armchair', 'Pablo Picasso painted numerous portraits of the many women in his life. Often the circumstances surrounding his relationships or the distinct personalities of his sitters seem to have precipitated stylistic changes in his work. Marie-Thérèse Walter came into the artist’s life around 1925. Though twenty-eight years older and married, the smitten artist began to furtively reference her blond hair, broad features, and voluptuous body in his work. Perhaps acknowledging the double life they were leading, he devised a new motif: a face that encompasses both frontal and profile views.</br>Picasso experimented beyond form and style, exploring different materials—including found objects such as newspaper, wallpaper, and even studio scraps—in his work. The Red Armchair demonstrates the artist’s innovative use of Ripolin, an industrial house paint that he first employed as early as 1912 for its brilliant colors as well as for its ability to provide an almost brushless finish if used straight from the can. In preparation for an exhibition of his work at the Galeries Georges Petit in 1931, Picasso began a series of large paintings of Walter, of which The Red Armchair was the first. Here he mixed Ripolin with oil to produce a wide range of surface effects—from the crisp brush marks in the yellow background to the thick but leveled look of the white face and the smooth black outlines of the figure.', 
		5, 'The Red Armchair.jpg', 8200, 27, 5, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Beggar with Crutch', 'Christian Zervos, Pablo Picasso, I (Paris, 1932), p. 99, no. 222 (ill.).', 
		5, 'Beggar with Crutch.jpg', 6500, 28, 4, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Daniel Henry Kahnweiler', 'The subject of this portrait is Daniel-Henry Kahnweiler (1884–1979), a German-born art dealer, writer, and publisher. Kahnweiler opened an art gallery in Paris in 1907 and in 1908 began representing Pablo Picasso, whom he introduced to Georges Braque. Kahnweiler was a great champion of the artists’ revolutionary experiment with Cubism and purchased the majority of their paintings between 1908 and 1915. He also wrote an important book, The Rise of Cubism, in 1920, which offered a theoretical framework for the movement.', 
		5, 'Daniel Henry Kahnweiler.jpg', 7200, 16, 4, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Head of a Woman', '(62.5 x 48)</br>Gouache, watercolor, and black and ochre chalks, manipulated with stump and wet brush, on cream laid paper', 
		5, 'Head of a Woman.jpg', 3200, 28, 4, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Portrait of Sylvette David', '(130.7 x 97.2)</br>Oil on canvas', 
		5, 'Portrait of Sylvette David.jpg', 6700, 31, 4, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('Man with a Pipe', '(130.2 × 89.5)</br>Oil on canvas', 
		5, 'Man with a Pipe.jpg', 8400, 24, 4, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('American Gothic', 'This familiar image was exhibited publicly for the first time at the Art Institute of Chicago, winning a three-hundred-dollar prize and instant fame for Grant Wood. The impetus for the painting came while Wood was visiting the small town of Eldon in his native Iowa. There he spotted a little wood farmhouse, with a single oversized window, made in a style called Carpenter Gothic. “I imagined American Gothic people with their faces stretched out long to go with this American Gothic house,” he said. He used his sister and his dentist as models for a farmer and his daughter, dressing them as if they were “tintypes from my old family album.” The highly detailed, polished style and the rigid frontality of the two figures were inspired by Flemish Renaissance art, which Wood studied during his travels to Europe between 1920 and 1928. After returning to settle in Iowa, he became increasingly appreciative of midwestern traditions and culture, which he celebrated in works such as this. American Gothic, often understood as a satirical comment on the midwestern character, quickly became one of America’s most famous paintings and is now firmly entrenched in the nation’s popular culture. Yet Wood intended it to be a positive statement about rural American values, an image of reassurance at a time of great dislocation and disillusionment. The man and woman, in their solid and well-crafted world, with all their strengths and weaknesses, represent survivors.', 
		6, 'American Gothic.jpg', 3200, 5, 4, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Product]([Title],[Description],[ArtistId],[Image],[Price],[QuantitySold],[AvgStars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])
VALUES ('The Pump', 'This image of a contemporary water pump would have been a perfect fit for Lewis’s novel about life in a midwestern town. The drawing was given to the Art Institute by Carter Manny, Jr., who received it as a high school graduation gift from the artist in 1937.', 
		6, 'The Pump.jpg', 3200, 5, 4, GETDATE(), 1, GETDATE(), 1)
GO

---------------------- TABLE ORDER NUMBER ----------------------------

INSERT INTO [dbo].[OrderNumber] (Number, CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES (1001, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[OrderNumber] (Number, CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES (1002, GETDATE(), 1, GETDATE(), 1)

GO

---------------------- TABLE ORDER --------------------------------------
INSERT INTO [dbo].[Order] (UserId, OrderDate, TotalPrice, OrderNumber, ItemCount, CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES (1, GETDATE(), 10000, 1001, 1, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[Order] (UserId, OrderDate, TotalPrice, OrderNumber, ItemCount, CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES (1, GETDATE(), 13000, 1002, 2, GETDATE(), 1, GETDATE(), 1)

GO

------------------------TABLE ORDER DETAIL ----------------------------

INSERT INTO [dbo].[OrderDetail] (OrderId, ProductId, Price, Quantity, CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES (1, 1, 10000, 1, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[OrderDetail] (OrderId, ProductId, Price, Quantity, CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES (2, 6, 5000, 1, GETDATE(), 1, GETDATE(), 1)

INSERT INTO [dbo].[OrderDetail] (OrderId, ProductId, Price, Quantity, CreatedOn, CreatedBy, ChangedOn, ChangedBy)
VALUES (2, 8, 8000, 1, GETDATE(), 1, GETDATE(), 1)
