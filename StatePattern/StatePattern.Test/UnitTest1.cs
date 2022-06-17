using NUnit.Framework;
using State;
using System;

namespace StatePattern.Test
{
    public class Tests
    {
        private PlayerContext _playerContext;

        [SetUp]
        public void Setup()
        {
            _playerContext = new PlayerContext(10);
        }

        [Test]
        public void TransistionToFightingFromIdleWhenAttacked()
        {
            Context context = new Context(10, 3, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(2);
            Assert.AreEqual("Fighting", context.CurrentStateString());
        }
        
        [Test]
        public void TransistionToFleeFromIdleWhenAttacked()
        {
            Context context = new Context(10, 3, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(8);
            Assert.AreEqual("Flee", context.CurrentStateString());
        }

        [Test]
        public void TransistionToIdleFromFightingWhenNoTarget()
        {
            Context context = new Context(10, 3, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(2);
            Assert.AreEqual("Fighting", context.CurrentStateString());
            context.NoTarget();
            Assert.AreEqual("Idle", context.CurrentStateString());
        }

        [Test]
        public void StayIdleWhenNoTarget()
        {
            Context context = new Context(10, 3, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.NoTarget();
            Assert.AreEqual("Idle", context.CurrentStateString());
        }

        [Test]
        public void TransistionToDeadFromIdleWhenTooMuchDamageRecieved()
        {
            Context context = new Context(10, 1, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(10);
            Assert.AreEqual("Dead", context.CurrentStateString());
        }

        [Test]
        public void TransistionToDeadWhenNegativeLife()
        {
            Context context = new Context(10, 1, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(1000000);
            Assert.AreEqual("Dead", context.CurrentStateString());
        }

        [Test]
        public void TransistionToDeadFromFightingWhenTooMuchDamageRecieved()
        {
            Context context = new Context(10, 1, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(1);
            Assert.AreEqual("Fighting", context.CurrentStateString());
            context.Attack(1);
            Assert.AreEqual("Fighting", context.CurrentStateString());
            context.Attack(10);
            Assert.AreEqual("Dead", context.CurrentStateString());
        }

        [Test]
        public void TransistionToDeadFromFleeWhenTooMuchDamageRecieved()
        {
            Context context = new Context(10, 1, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(8);
            Assert.AreEqual("Flee", context.CurrentStateString());
            context.Attack(2);
            Assert.AreEqual("Dead", context.CurrentStateString());
        }

        [Test]
        public void TransistionToFightingIfNoTarget()
        {
            Context context = new Context(10, 3, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Seen();
            Assert.AreEqual("Fighting", context.CurrentStateString());
        }

        [Test]
        public void TransistionToIdleFromFleeIfNoTarget()
        {
            Context context = new Context(10, 3, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(9);
            Assert.AreEqual("Flee", context.CurrentStateString());
            context.NoTarget();
            Assert.AreEqual("Idle", context.CurrentStateString());
            context.NoTarget();
        }
        [Test]
        public void TransistionToIdleWhenPlayerDefeated()
        {
            Context context = new Context(10, 6, _playerContext);

            Assert.AreEqual("Idle", context.CurrentStateString());
            context.Attack(0);
            Assert.AreEqual("Fighting", context.CurrentStateString());
            context.Attack(0);
            Assert.AreEqual("Idle", context.CurrentStateString());
        }

        [Test]
        public void StateContextCanNotBeNull()
        {
            void del() {new NewState(null, 1, 1); }
            Assert.Throws<ArgumentNullException>(del);
        }

        [Test]
        public void PlayerContextMustHavePositiveLife()
        {
            void del() { PlayerContext testPlayer1 = new PlayerContext(0); }
            Assert.Throws<ArgumentException>(del);

            void del2() { PlayerContext testPlayer2 = new PlayerContext(-1); }
            Assert.Throws<ArgumentException>(del2);
        }

        [Test]
        public void ContextMustHavePositiveLife()
        {
            void del() { Context testPlayer1 = new Context(0, 1, _playerContext); }
            Assert.Throws<ArgumentException>(del);

            void del2() { Context testPlayer2 = new Context(-1, 1, _playerContext); }
            Assert.Throws<ArgumentException>(del2);
        }

        [Test]
        public void ContextMustHavePositiveDamage()
        {
            void del() { Context testPlayer1 = new Context(10, 0, _playerContext); }
            Assert.Throws<ArgumentException>(del);

            void del2() { Context testPlayer2 = new Context(10, -1, _playerContext); }
            Assert.Throws<ArgumentException>(del2);
        }

        [Test]
        public void ContextMustNotHaveNullPlayerContext()
        {
            void del() { Context testPlayer1 = new Context(10, 1, null); }
            Assert.Throws<ArgumentNullException>(del);
        }
    }
}