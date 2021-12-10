-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 25, 2019 at 03:30 AM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fractal_generator`
--

-- --------------------------------------------------------

--
-- Table structure for table `fractal`
--

CREATE TABLE `fractal` (
  `id` int(200) NOT NULL,
  `name` varchar(200) NOT NULL,
  `description` text NOT NULL,
  `thumb_url` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `fractal`
--

INSERT INTO `fractal` (`id`, `name`, `description`, `thumb_url`) VALUES
(1, 'Mandelbrot set', 'The Mandelbrot set is a famous example of a fractal in mathematics. It is named after Benoît Mandelbrot, a Polish-French-American mathematician. The Mandelbrot set is important for the chaos theory. The edging of the set shows a self-similarity, which is not perfect because it has deformations.\r\n\r\nThe Mandelbrot set can be explained with the equation zn+1 = zn2 + c. In that equation, c and z are complex numbers and n is zero or a positive integer (natural number). Starting with z0=0, c is in the Mandelbrot set if the absolute value of zn never becomes larger than a certain number (that number depends on c), no matter how large n gets.\r\n\r\nMandelbrot was one of the first to use computer graphics to create and display fractal geometric images, leading to his discovering the Mandelbrot set in 1979. That was because he had access to IBM\'s computers. He was able to show how visual complexity can be created from simple rules. He said that things typically considered to be \"rough\", a \"mess\" or \"chaotic\", like clouds or shorelines, actually had a \"degree of order\". The equation zn+1 = zn2 + c was known long before Benoit Mandelbrot used a computer to visualize it.\r\n\r\nImages are created by applying the equation to each pixel in an iterative process, using the pixel\'s position in the image for the number \'c\'. \'c\' is obtained by mapping the position of the pixel in the image relative to the position of the point on the complex plane. \r\n\r\nThe Mandelbrot set can be explained with the equation zn+1 = zn2 + c. In that equation, c and z are complex numbers and n is zero or a positive integer (natural number). Starting with z0=0, c is in the Mandelbrot set if the absolute value of zn never becomes larger than a certain number (that number depends on c), no matter how large n gets.\r\n\r\nMandelbrot was one of the first to use computer graphics to create and display fractal geometric images, leading to his discovering the Mandelbrot set in 1979. That was because he had access to IBM\'s computers. He was able to show how visual complexity can be created from simple rules. He said that things typically considered to be \"rough\", a \"mess\" or', '600px-Mandelbrot_set_-_Normal_mapping.png'),
(2, 'Sierpinski Triangle', 'The Sierpiński gasket (in French: \"tamis de Sierpiński\" ) — along with its companion, the Sierpiński carpet, or \"tapis de Sierpiński\" — belongs to the toolkit of every fractal geometer. It adorns many articles and books on the subject and is frequently used as an example or test case in various mathematical and physical studies of self-similarity. Although it is geometrically more complex than the classic Cantor set, it is still one of the simplest interesting fractals. It was introduced in 1915 [a38] by the Polish mathematician W. Sierpiński, about forty years after the discovery of the Cantor set.\r\n\r\nLike other self-similar fractals, the Sierpiński gasket is constructed iteratively. Beginning with an equilateral triangle, an inverted triangle with half the side-length of the original is removed. This process is then repeated with each of the remaining triangles ad infinitum ', 'Sierpinski-triangle-Error-Reference-source-not-found.png'),
(3, 'Lorenz Attractor', ' The lorenz attractor was first studied by Ed N. Lorenz, a meteorologist, around 1963. It was derived from a simplified model of convection in the earth\'s atmosphere. It also arises naturally in models of lasers and dynamos. The system is most commonly expressed as 3 coupled non-linear differential equations.\r\ndx / dt = a (y - x)\r\n\r\ndy / dt = x (b - z) - y\r\n\r\ndz / dt = xy - c z\r\n\r\nOne commonly used set of constants is a = 10, b = 28, c = 8 / 3. Another is a = 28, b = 46.92, c = 4. \"a\" is sometimes known as the Prandtl number and \"b\" the Rayleigh number.\r\n\r\nThe series does not form limit cycles nor does it ever reach a steady state. Instead it is an example of deterministic chaos. As with other chaotic systems the Lorenz system is sensitive to the initial conditions, two initial states no matter how close will diverge, usually sooner rather than later. ', 'index.jpg'),
(4, 'Barnsley fern', 'The fern is one of the basic examples of self-similar sets, i.e. it is a mathematically generated pattern that can be reproducible at any magnification or reduction. Like the Sierpinski triangle, the Barnsley fern shows how graphically beautiful structures can be built from repetitive uses of mathematical formulas with computers. Barnsley\'s 1988 book Fractals Everywhere is based on the course which he taught for undergraduate and graduate students in the School of Mathematics, Georgia Institute of Technology, called Fractal Geometry. After publishing the book, a second course was developed, called Fractal Measure Theory.[1] Barnsley\'s work has been a source of inspiration to graphic artists attempting to imitate nature with mathematical models. ', 'Visualisation_of_Barnsley_Fern_in_Processing.png'),
(5, 'Cellular Automata', ' cellular automaton (pl. cellular automata, abbrev. CA) is a discrete model studied in computer science, mathematics, physics, complexity science, theoretical biology and microstructure modeling. Cellular automata are also called cellular spaces, tessellation automata, homogeneous structures, cellular structures, tessellation structures, and iterative arrays.[2]\r\n\r\nA cellular automaton consists of a regular grid of cells, each in one of a finite number of states, such as on and off (in contrast to a coupled map lattice). The grid can be in any finite number of dimensions. For each cell, a set of cells called its neighborhood is defined relative to the specified cell. An initial state (time t = 0) is selected by assigning a state for each cell. A new generation is created (advancing t by 1), according to some fixed rule (generally, a mathematical function)[3] that determines the new state of each cell in terms of the current state of the cell and the states of the cells in its neighborhood. Typically, the rule for updating the state of cells is the same for each cell and does not change over time, and is applied to the whole grid simultaneously,[4] though exceptions are known, such as the stochastic cellular automaton and asynchronous cellular automaton. ', 'indexxxx.jpg'),
(6, 'Koch Snowflake', 'The Koch snowflake (also known as the Koch curve, Koch star, or Koch island[1][2]) is a mathematical curve and one of the earliest fractals to have been described. It is based on the Koch curve, which appeared in a 1904 paper titled \"On a Continuous Curve Without Tangents, Constructible from Elementary Geometry\"[3] by the Swedish mathematician Helge von Koch.\r\n\r\nThe Koch snowflake can be built up iteratively, in a sequence of stages. The first stage is an equilateral triangle, and each successive stage is formed from adding outward bends to each side of the previous stage, making smaller equilateral triangles. The areas enclosed by the successive stages in the construction of the snowflake converge to 8/5 times the area of the original triangle, while the perimeters of the successive stages increase without bound. Consequently, the snowflake encloses a finite area, but has an infinite perimeter. ', 'kochprog440z.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `image`
--

CREATE TABLE `image` (
  `id` int(200) NOT NULL,
  `url` varchar(200) NOT NULL,
  `fractal_id` int(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `image`
--

INSERT INTO `image` (`id`, `url`, `fractal_id`) VALUES
(1, 'Mandel_zoom_07_satellite.jpg', 1),
(2, '800px-Mandel_zoom_00_mandelbrot_set.jpg', 1),
(3, 'mandelbrot-circle.png', 1),
(4, 'Screenshot-1613.png', 2),
(5, 'mb2C8.png', 2),
(6, 'Sierpinski_pyramidpng', 2),
(7, 'Lorenz_attractor_9.png', 3),
(8, 'il_570xN.1613905834_bupr.jpg', 3),
(9, 'images.jpg', 3),
(10, 'fractal-ferns-kathleene-berger.jpg', 4),
(11, 'd8yuxuq-94797c27-94fc-42ad-b167-5fcc47308530.png', 4),
(12, 'imagess.jpg', 4),
(13, '39020321855_3201b36870_o.png', 5),
(14, 'xxxxaaa.jpg', 5),
(15, 'indexasdfasdfasdf.jpg', 5),
(16, '0e745b8b15fec5357133391ca1bb07cf.jpg', 6),
(17, 'imagesadsfasdfas.jpg', 6),
(18, 'koch-snowflake.png', 6);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `fractal`
--
ALTER TABLE `fractal`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `image`
--
ALTER TABLE `image`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_fractal_img` (`fractal_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `fractal`
--
ALTER TABLE `fractal`
  MODIFY `id` int(200) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `image`
--
ALTER TABLE `image`
  MODIFY `id` int(200) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `image`
--
ALTER TABLE `image`
  ADD CONSTRAINT `fk_fractal_img` FOREIGN KEY (`fractal_id`) REFERENCES `fractal` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
