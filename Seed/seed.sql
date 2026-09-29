USE NetGameDB;
-- -- docker exec -i mysql-db mysql -uroot -pPassword123 NetGameDB < Seed/seed.sql
-- -- Pegi
-- INSERT INTO PEGI (Id, Age, Description) VALUES
-- (1, '3', 'Suitable for all ages'),
-- (2, '7', 'Mild violence or scary content'),
-- (3, '12', 'Moderate violence, mild bad language'),
-- (4, '16', 'Realistic violence, drug references'),
-- (5, '18', 'Graphic violence, gambling, strong language');

-- -- Genre
-- INSERT INTO Genre (Id, Name) VALUES
-- (1, 'Action'),
-- (2, 'RPG'),
-- (3, 'Strategy'),
-- (4, 'Sports'),
-- (5, 'Puzzle'),
-- (6, 'Horror');

-- -- Product
-- INSERT INTO Product (Id, Name, Description, Price, ProductImageUrl, IsActive) VALUES
-- (1, 'Shadow Realm', 'An open-world action RPG set in a dark fantasy universe.', 59.99, 'https://picsum.photos/seed/shadowrealm/400/300', 1),
-- (2, 'Circuit Breakers', 'Fast-paced futuristic racing with destructible tracks.', 39.99, 'https://picsum.photos/seed/circuitbreakers/400/300', 1),
-- (3, 'Kingdom Tactics', 'Turn-based strategy across a fractured medieval kingdom.', 29.99, 'https://picsum.photos/seed/kingdomtactics/400/300', 1),
-- (4, 'Puzzle Grove', 'Relaxing puzzle adventure through a magical forest.', 14.99, 'https://picsum.photos/seed/puzzlegrove/400/300', 1),
-- (5, 'Nightmare Corridor', 'A first-person survival horror experience.', 24.99, 'https://picsum.photos/seed/nightmarecorridor/400/300', 1);

-- -- Game (linked 1:1 to Product, optional Pegi)
-- INSERT INTO Game (Id, PegiId, ProductId) VALUES
-- (1, 4, 1),
-- (2, 3, 2),
-- (3, 3, 3),
-- (4, 1, 4),
-- (5, 5, 5);

-- -- GameGenre (many-to-many join table)
-- INSERT INTO GameGenre (GameId, GenreId) VALUES
-- (1, 1), (1, 2),
-- (2, 1), (2, 4),
-- (3, 3), (3, 2),
-- (4, 5),
-- (5, 6), (5, 1);

-- -- Customer (unused by FKs currently, but seeding since the table exists)
-- INSERT INTO Customer (Id, FirstName, LastName, Email, Password, Phonenumber, Address, RegistrationDate) VALUES
-- (0, 'Test', 'Person', 'admin@netgame.local', 'hashed_placeholder', '0701234567', 'Storgatan 1, Gothenburg', NOW());
-- -- (1, 'Anna', 'Karlsson', 'anna.karlsson@example.com', 'hashed_placeholder', '0701234567', 'Storgatan 1, Gothenburg', NOW()),
-- -- (2, 'Erik', 'Svensson', 'erik.svensson@example.com', 'hashed_placeholder', '0709876543', 'Kungsgatan 5, Stockholm', NOW());

-- -- Admin
-- INSERT INTO Admin (Id, FirstName, LastName, Email, Password) VALUES
-- (1, 'Site', 'Admin', 'admin@netgame.local', 'hashed_placeholder');

-- -- Shopping cart with items
-- INSERT INTO ShoppingCart (Id, CustomerId, CreatedAt) VALUES
-- (1, '0', NOW());

-- INSERT INTO ShoppingCartItem (Id, CartId, ProductId, Quantity, PriceAtPurchase) VALUES
-- (1, 1, 2, 1, 39.99),
-- (2, 1, 4, 2, 14.99);

-- -- Completed order with items
-- INSERT INTO `Order` (Id, CustomerId, OrderDate, Status) VALUES
-- (1, '0', NOW(), 'Completed');

-- INSERT INTO OrderItem (Id, OrderId, ProductId, Quantity, PriceAtPurchase) VALUES
-- (1, 1, 1, 1, 59.99),
-- (2, 1, 3, 1, 29.99);

-- -- Reviews
-- INSERT INTO Review (Id, Rating, ReviewText, CreatedDate, CustomerId, ProductId) VALUES
-- (1, 5, 'Absolutely loved the atmosphere and story in Shadow Realm.', NOW(), '0', 1),
-- (2, 4, 'Kingdom Tactics has great depth but the pacing is slow at first.', NOW(), '0', 3);

INSERT INTO Product (Id, Name, Description, Price, ProductImageUrl, IsActive) VALUES
(6, 'Wireless Gaming Controller', 'Ergonomic wireless controller with 40-hour battery life.', 49.99, 'https://picsum.photos/seed/controller/400/300', 1),
(7, 'RGB Mechanical Keyboard', 'Hot-swappable mechanical keyboard with per-key RGB lighting.', 89.99, 'https://picsum.photos/seed/keyboard/400/300', 1),
(8, 'Gaming Headset Pro', '7.1 surround sound headset with detachable microphone.', 69.99, 'https://picsum.photos/seed/headset/400/300', 1),
(9, 'XL Desk Mat', 'Extended stitched-edge mouse and keyboard mat, 90x40 cm.', 24.99, 'https://picsum.photos/seed/deskmat/400/300', 1),
(10, 'Shadow Realm Collector''s Figure', 'Limited 25 cm collectible figure from Shadow Realm.', 79.99, 'https://picsum.photos/seed/figure/400/300', 1);

INSERT INTO PhysicalProduct (ProductId, StockQuantity) VALUES
(6, 45),
(7, 30),
(8, 60),
(9, 100),
(10, 12);


-- SET @uid = (SELECT Id FROM AspNetUsers WHERE Email = 'admin@netgame.local');

-- INSERT INTO Review (Rating, ReviewText, CreatedDate, CustomerId, ProductId) VALUES
-- -- 1: Shadow Realm
-- (5, 'Stunning world and a story that kept me hooked for 60 hours.', DATE_SUB(NOW(), INTERVAL 30 DAY), @uid, 1),
-- (4, 'Combat feels great, though the map markers get cluttered.', DATE_SUB(NOW(), INTERVAL 24 DAY), @uid, 1),
-- (5, 'Best dark fantasy RPG I have played in years.', DATE_SUB(NOW(), INTERVAL 19 DAY), @uid, 1),
-- (3, 'Beautiful, but a few quests are repetitive and there are some bugs.', DATE_SUB(NOW(), INTERVAL 12 DAY), @uid, 1),
-- (4, 'Great boss fights and a soundtrack worth owning.', DATE_SUB(NOW(), INTERVAL 5 DAY), @uid, 1),

-- -- 2: Circuit Breakers
-- (5, 'Destructible tracks make every race unpredictable. Love it.', DATE_SUB(NOW(), INTERVAL 28 DAY), @uid, 2),
-- (4, 'Very fast and polished, but I would like more car variety.', DATE_SUB(NOW(), INTERVAL 22 DAY), @uid, 2),
-- (3, 'Fun for short sessions, though the AI rubber-bands too much.', DATE_SUB(NOW(), INTERVAL 17 DAY), @uid, 2),
-- (5, 'Online multiplayer is smooth and chaotic in the best way.', DATE_SUB(NOW(), INTERVAL 9 DAY), @uid, 2),
-- (4, 'Great sense of speed. The career mode could be longer.', DATE_SUB(NOW(), INTERVAL 3 DAY), @uid, 2),

-- -- 3: Kingdom Tactics
-- (5, 'Deep, rewarding strategy. Every turn matters.', DATE_SUB(NOW(), INTERVAL 27 DAY), @uid, 3),
-- (4, 'Great depth, but the first few hours are slow.', DATE_SUB(NOW(), INTERVAL 21 DAY), @uid, 3),
-- (4, 'Smart unit balance and lots of replayability.', DATE_SUB(NOW(), INTERVAL 15 DAY), @uid, 3),
-- (2, 'The UI is clunky and the tutorial explains too little.', DATE_SUB(NOW(), INTERVAL 10 DAY), @uid, 3),
-- (5, 'Perfect for fans of turn-based tactics. Hard to put down.', DATE_SUB(NOW(), INTERVAL 4 DAY), @uid, 3),

-- -- 4: Puzzle Grove
-- (5, 'Relaxing, charming and clever. My go-to game to unwind.', DATE_SUB(NOW(), INTERVAL 26 DAY), @uid, 4),
-- (4, 'Lovely art style, and the puzzles ramp up nicely.', DATE_SUB(NOW(), INTERVAL 20 DAY), @uid, 4),
-- (5, 'Played it with my kids and we all loved it.', DATE_SUB(NOW(), INTERVAL 14 DAY), @uid, 4),
-- (3, 'Cozy, but a bit short and a little easy.', DATE_SUB(NOW(), INTERVAL 8 DAY), @uid, 4),
-- (4, 'Great value for the price and a calming soundtrack.', DATE_SUB(NOW(), INTERVAL 2 DAY), @uid, 4),

-- -- 5: Nightmare Corridor
-- (5, 'Genuinely terrifying. The sound design is incredible.', DATE_SUB(NOW(), INTERVAL 29 DAY), @uid, 5),
-- (4, 'Tense atmosphere, though the jump scares get predictable.', DATE_SUB(NOW(), INTERVAL 23 DAY), @uid, 5),
-- (3, 'Great first half, but the ending felt rushed.', DATE_SUB(NOW(), INTERVAL 16 DAY), @uid, 5),
-- (5, 'Played with headphones in the dark. Never again, 10/10.', DATE_SUB(NOW(), INTERVAL 7 DAY), @uid, 5),
-- (4, 'Short but very effective survival horror.', DATE_SUB(NOW(), INTERVAL 1 DAY), @uid, 5),

-- -- 6: Wireless Gaming Controller
-- (5, 'Comfortable grip and the battery easily lasts a week.', DATE_SUB(NOW(), INTERVAL 25 DAY), @uid, 6),
-- (4, 'Solid build quality and responsive triggers.', DATE_SUB(NOW(), INTERVAL 18 DAY), @uid, 6),
-- (4, 'Pairs instantly with my PC and phone. Very happy.', DATE_SUB(NOW(), INTERVAL 13 DAY), @uid, 6),
-- (2, 'The left stick started drifting after two months.', DATE_SUB(NOW(), INTERVAL 6 DAY), @uid, 6),
-- (5, 'Best controller I have owned at this price.', DATE_SUB(NOW(), INTERVAL 2 DAY), @uid, 6),

-- -- 7: RGB Mechanical Keyboard
-- (5, 'Great typing feel, and the hot-swap switches are a big plus.', DATE_SUB(NOW(), INTERVAL 26 DAY), @uid, 7),
-- (4, 'Sturdy, with beautiful lighting. A little loud for the office.', DATE_SUB(NOW(), INTERVAL 20 DAY), @uid, 7),
-- (5, 'Swapped in linear switches and it feels amazing.', DATE_SUB(NOW(), INTERVAL 14 DAY), @uid, 7),
-- (3, 'Good keyboard, but the software is clumsy.', DATE_SUB(NOW(), INTERVAL 8 DAY), @uid, 7),
-- (4, 'Excellent build quality for the money.', DATE_SUB(NOW(), INTERVAL 3 DAY), @uid, 7),

-- -- 8: Gaming Headset Pro
-- (4, 'Clear positional audio, and I noticed footsteps in shooters immediately.', DATE_SUB(NOW(), INTERVAL 27 DAY), @uid, 8),
-- (5, 'Very comfortable even after long sessions.', DATE_SUB(NOW(), INTERVAL 21 DAY), @uid, 8),
-- (3, 'Sound is great, but the microphone is only average.', DATE_SUB(NOW(), INTERVAL 15 DAY), @uid, 8),
-- (4, 'Detachable mic is handy and the cable feels durable.', DATE_SUB(NOW(), INTERVAL 9 DAY), @uid, 8),
-- (5, 'Huge upgrade over my old headset.', DATE_SUB(NOW(), INTERVAL 4 DAY), @uid, 8),

-- -- 9: XL Desk Mat
-- (5, 'Fits my keyboard and mouse perfectly, and the surface is smooth.', DATE_SUB(NOW(), INTERVAL 24 DAY), @uid, 9),
-- (4, 'Stitched edges have held up well so far.', DATE_SUB(NOW(), INTERVAL 19 DAY), @uid, 9),
-- (5, 'Makes my desk look a lot more put together.', DATE_SUB(NOW(), INTERVAL 12 DAY), @uid, 9),
-- (3, 'Nice mat, but it had a slight smell for the first few days.', DATE_SUB(NOW(), INTERVAL 6 DAY), @uid, 9),
-- (4, 'Great value and easy to wipe clean.', DATE_SUB(NOW(), INTERVAL 1 DAY), @uid, 9),

-- -- 10: Shadow Realm Collector's Figure
-- (5, 'Incredible detail and paint work. It looks great on my shelf.', DATE_SUB(NOW(), INTERVAL 23 DAY), @uid, 10),
-- (4, 'Well made and heavy, but the packaging was a bit dented.', DATE_SUB(NOW(), INTERVAL 17 DAY), @uid, 10),
-- (5, 'A must-have for any Shadow Realm fan.', DATE_SUB(NOW(), INTERVAL 11 DAY), @uid, 10),
-- (3, 'Beautiful figure, but a little pricey for the size.', DATE_SUB(NOW(), INTERVAL 5 DAY), @uid, 10),
-- (5, 'Even better in person than in the photos.', DATE_SUB(NOW(), INTERVAL 2 DAY), @uid, 10);