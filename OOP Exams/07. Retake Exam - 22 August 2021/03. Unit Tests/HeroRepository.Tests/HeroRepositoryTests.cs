using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private const string DEF_HERO_NAME = "Hero";
    private const int DEF_HERO_LEVEL = 1;

    private Hero hero;
    private HeroRepository repo;

    [SetUp]
    public void Setup()
    {
        hero = new Hero(DEF_HERO_NAME, DEF_HERO_LEVEL);
        repo = new HeroRepository();
    }

    [Test]
    public void HeroConstructor_CreatesObjectProperly()
    {
        Assert.True(hero.Name == DEF_HERO_NAME && hero.Level == DEF_HERO_LEVEL);
    }

    [Test]
    public void Create_ThrowsForNullHero()
    {
        Assert.Throws<ArgumentNullException>(() => repo.Create(null));
    }

    [Test]
    public void Create_ThrowsForExistingHeroName()
    {
        repo.Create(hero);
        Assert.Throws<InvalidOperationException>(() => repo.Create(new Hero(DEF_HERO_NAME, 1)));
    }

    [Test]
    public void Create_AddsNewHeroToTheCollection()
    {
        repo.Create(hero);
        Assert.AreEqual(repo.Heroes.Count, 1);
        Assert.AreSame(repo.Heroes.First(), hero);
    }

    [TestCase(null)]
    [TestCase(" ")]
    public void Remove_ThrowsForNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() => repo.Remove(name));
    }

    [Test]
    public void Remove_RemovesTheItemFromTheCollection()
    {
        repo.Create(hero);
        bool removed = repo.Remove(hero.Name);
        Assert.AreEqual(repo.Heroes.Count, 0);
        Assert.IsTrue(removed);
    }

    [Test]
    public void GetHeroWithHighestLevel_ReturnsProperHero()
    {
        Hero hero2 = new Hero("Token name", 5);
        Hero hero3 = new Hero("token name 2", 4);

        repo.Create(hero);
        repo.Create(hero2);
        repo.Create(hero3);

        Hero expectedHero = new List<Hero>() { hero, hero2, hero3 }.OrderByDescending(x => x.Level).FirstOrDefault();
        Assert.AreEqual(expectedHero, repo.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHero_FindsCorrectHero()
    {
        repo.Create(hero);
        Hero heroFound = repo.GetHero(hero.Name);
        Assert.AreSame(hero, heroFound);
    }
}