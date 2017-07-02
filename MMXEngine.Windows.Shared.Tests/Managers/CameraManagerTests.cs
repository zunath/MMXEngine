using System;
using Microsoft.Xna.Framework;
using MMXEngine.Contracts.Managers;
using MMXEngine.Testing.Shared.MockObjects;
using MMXEngine.Windows.Shared.Managers;
using NUnit.Framework;

namespace MMXEngine.Windows.Shared.Tests.Managers
{
    [TestFixture]
    public class CameraManagerTests
    {
        private ICameraManager _camera;

        [SetUp]
        public void SetUp()
        {
            _camera = new CameraManager(GraphicsDeviceMock.Current.GraphicsDevice);
        }

        [Test]
        public void CameraManager_Constructor_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                // ReSharper disable once ObjectCreationAsStatement
                new CameraManager(GraphicsDeviceMock.Current.GraphicsDevice);
            });
        }

        [Test]
        public void CameraManager_Constructor_ValuesShouldMatch()
        {
            Assert.AreEqual(Vector2.Zero, _camera.Position);
            Assert.AreEqual(3.0f, _camera.Zoom);
        }
        
        [Test]
        public void CameraManager_Zoom_GetAndSet_ShouldMatch()
        {
            var originalValue = _camera.Zoom;
            _camera.Zoom = 500.0f;
            Assert.AreEqual(500.0f, _camera.Zoom);
            _camera.Zoom = originalValue;
        }

        [Test]
        public void CameraManager_Rotation_GetAndSet_ShouldMatch()
        {
            var originalValue = _camera.Rotation;
            _camera.Rotation = 20.0f;
            Assert.AreEqual(20.0f, _camera.Rotation);
            _camera.Rotation = originalValue;
        }

        [Test]
        public void CameraManager_Position_GetAndSet_ShouldMatch()
        {
            var originalValue = _camera.Position;
            _camera.Position = new Vector2(345, 543);
            Assert.AreEqual(new Vector2(345, 543), _camera.Position);
            _camera.Position = originalValue;
        }

        [Test]
        public void CameraManager_WorldToScreen_OverloadsShouldEqual()
        {
            var result = _camera.WorldToScreen(50.0f, 50.0f);
            var result2 = _camera.WorldToScreen(new Vector2(50.0f, 50.0f));

            Assert.AreEqual(result, result2);
        }

        [Test]
        public void CameraManager_WorldToScreen_XY_ShouldEqualNegative1130Negative570()
        {
            const int x = -1130;
            const int y = -570;
            var result = _camera.WorldToScreen(50.0f, 50.0f);
            Assert.AreEqual(x, result.X);
            Assert.AreEqual(y, result.Y);
        }

        [Test]
        public void CameraManager_WorldToScreen_Vector2_ShouldEqualNegative1130Negative570()
        {
            var position = new Vector2(-1130, -570);
            var result = _camera.WorldToScreen(new Vector2(50.0f, 50.0f));
            Assert.AreEqual(position, result);
        }

        [Test]
        public void CameraManager_ScreenToWorld_XY_ShouldEqualX50Y50()
        {
            const float x = 50.0f;
            const float y = 50.0f;
            var result = _camera.ScreenToWorld(-1130, -570);
            
            Assert.AreEqual(x, result.X, 0.001f);
            Assert.AreEqual(y, result.Y, 0.001f);
        }

        [Test]
        public void CameraManager_ScreenToWorld_Vector2_ShouldEqualX50Y50()
        {
            var position = new Vector2(50.0f, 50.0f);
            var result = _camera.ScreenToWorld(new Vector2(-1130, -570));

            Assert.AreEqual(position.X, result.X, 0.001f);
            Assert.AreEqual(position.Y, result.Y, 0.001f);
        }

        [Test]
        public void CameraManager_Focus_Vector2_PositionShouldMatch()
        {
            Assert.AreEqual(0.0f, _camera.Position.X);
            Assert.AreEqual(0.0f, _camera.Position.Y);

            var position = new Vector2(50.0f, 30.0f);
            _camera.Focus(position);

            Assert.AreEqual(-590.0f, _camera.Position.X);
            Assert.AreEqual(-330.0f, _camera.Position.Y);

            _camera.Position = new Vector2(0.0f, 0.0f);
        }

        [Test]
        public void CameraManager_Focus_XY_PositionShouldMatch()
        {
            Assert.AreEqual(0.0f, _camera.Position.X);
            Assert.AreEqual(0.0f, _camera.Position.Y);

            var x = 50.0f;
            var y = 30.0f;
            _camera.Focus(x, y);

            Assert.AreEqual(-590.0f, _camera.Position.X);
            Assert.AreEqual(-330.0f, _camera.Position.Y);

            _camera.Position = new Vector2(0.0f, 0.0f);
        }

        [Test]
        public void CameraManager_Move_XY_PositionShouldMatch()
        {
            Assert.AreEqual(0.0f, _camera.Position.X);
            Assert.AreEqual(0.0f, _camera.Position.Y);

            _camera.Move(15.0f, -5.0f);

            Assert.AreEqual(15.0f, _camera.Position.X);
            Assert.AreEqual(-5.0f, _camera.Position.Y);
        }


        [Test]
        public void CameraManager_Move_Vector2_PositionShouldMatch()
        {
            Assert.AreEqual(0.0f, _camera.Position.X);
            Assert.AreEqual(0.0f, _camera.Position.Y);

            _camera.Move(new Vector2(15.0f, -5.0f));

            Assert.AreEqual(15.0f, _camera.Position.X);
            Assert.AreEqual(-5.0f, _camera.Position.Y);
        }

        [Test]
        public void CameraManager_TopLeft_ShouldEqual()
        {
            Assert.AreEqual(426.666, _camera.TopLeft.X, 0.001f);
            Assert.AreEqual(240, _camera.TopLeft.Y, 0.001f);
        }
    }
}
