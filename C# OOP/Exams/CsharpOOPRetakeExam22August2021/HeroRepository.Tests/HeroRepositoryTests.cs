using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TestConstructor()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.AreEqual(0, heroRepository.Heroes.Count);
        Assert.IsNotNull(heroRepository.Heroes);
    }
    [Test]
    public void CreateMethod_ShouldThrowException_NullHero_InvalidData()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null), "Hero is null");
    }
    [Test]
    public void CreateMethod_ShouldThrowException_ExistingHero_InvalidData()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Mitko", 2);
        Hero hero2 = new Hero("Mitko", 3);

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero2), $"Hero with name {hero2.Name} already exists");
    }
    [Test]
    public void CreateMethod_ShouldCreateHero_ValidData()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Mitko", 2);
        Hero hero2 = new Hero("Mitko2", 3);

        var result1 = heroRepository.Create(hero);
        var result2 = heroRepository.Create(hero2);
        var expectedResult1 = $"Successfully added hero {hero.Name} with level {hero.Level}";
        var expectedResult2 = $"Successfully added hero {hero2.Name} with level {hero2.Level}";

        Assert.AreEqual(expectedResult1, result1);
        Assert.AreEqual(expectedResult2, result2);
    }
    [Test]
    public void RemoveMethod_ShouldThrowException_ExistingHero_InvalidData()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null), "Name cannot be null");
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(""), "Name cannot be null");
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(" "), "Name cannot be null");
    }
    [Test]
    public void RemoveeMethod_ShouldReturnTrue_ValidData()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Mitko", 2);
        Hero hero2 = new Hero("Mitko2", 3);
        Hero hero3 = new Hero("Mitko3", 4);
        Hero hero4 = new Hero("Mitko4", 5);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);
        var isRemoved1 = heroRepository.Remove(hero.Name);
        var isRemoved3 = heroRepository.Remove(hero3.Name);

        Assert.True(isRemoved1);
        Assert.True(isRemoved3);
        Assert.AreEqual(2, heroRepository.Heroes.Count);
    }
    [Test]
    public void GetHeroWithHighestLevelMethod_ShouldReturnHero_ValidData()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Mitko", 2);
        Hero hero2 = new Hero("Mitko2", 3);
        Hero hero3 = new Hero("Mitko3", 4);
        Hero hero4 = new Hero("Mitko4", 5);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);
        var returnedHero = heroRepository.GetHeroWithHighestLevel();

        Assert.AreSame(hero4, returnedHero);
        Assert.AreEqual(hero4.Level, returnedHero.Level);
    }

    [Test]
    public void GetHeroMethod_ShouldReturnHero_ValidData()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Mitko", 2);
        Hero hero2 = new Hero("Mitko2", 3);
        Hero hero3 = new Hero("Mitko3", 4);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        var returnedHero = heroRepository.GetHero(hero2.Name);

        Assert.AreSame(hero2, returnedHero);
        Assert.AreEqual(hero2.Level, returnedHero.Level);
    }

}