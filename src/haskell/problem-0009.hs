-- | A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
-- | a^2 + b^2 = c^2
-- | For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
-- |
-- | There exists exactly one Pythagorean triplet for which a + b + c = 1000.
-- | Find the product abc.

import Math.Pythagorean

main :: IO()
main = do
    -- | Euclid: a = 2mn; b = m^2-n^2; c = m^2+n^2
    -- | a + b + c = 1000
    -- | 2mn + (m^2-n^2) + (m^2+n^2) = 1000
    -- | 2mn + 2m^2 = 1000
    -- | 2m(m+n) = 1000;
    -- | m(m+n) = 500;
    -- | since m > n  m = 20; n = 5
    let triplet = solveTriplet 20 5 -- | (200,376,425)
        productOf (a,b,c) = a*b*c
        answer = productOf triplet

    print answer
