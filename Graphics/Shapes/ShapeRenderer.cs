using System.Collections.Generic;

using OpenTK.Graphics.OpenGL;

using ArcadiaEngine.Graphics.Shaders;
using ArcadiaEngine.Common.Geometry;
using ArcadiaEngine.Graphics.Sprites;
using System.Runtime.CompilerServices;

namespace ArcadiaEngine.Graphics.Shapes {
    internal class ShapeRenderer {
        public ShapeType shape;

        private int shape_info_buffer;

        private List<ShapeInfo> filled_shapes;
        private List<ShapeInfo> lined_shapes;

        public int count {
            get {
                return filled_shapes.Count + lined_shapes.Count;
            }
        }

        public ShapeRenderer(ShapeType type) {
            shape = type;

            shape_info_buffer = GL.GenBuffer();

            filled_shapes = new List<ShapeInfo>();
            lined_shapes = new List<ShapeInfo>();
        }

        public void add_shape(bool filled, params ShapeInfo[] shapes) {
            foreach(ShapeInfo shape in shapes) {
                if(filled)
                    filled_shapes.Add(shape);
                else
                    lined_shapes.Add(shape);
            }
        }

        public void draw() { 
            render_filled();
            render_lined();
        }

        private void bind_filled_info() {
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, shape_info_buffer);
            GL.BufferData(BufferTarget.ShaderStorageBuffer, filled_shapes.Count * Unsafe.SizeOf<ShapeInfo>(), filled_shapes.ToArray(), BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, 0);
            GL.BindBufferBase(BufferRangeTarget.ShaderStorageBuffer, 2, shape_info_buffer);
        }
        private void bind_lined_info() {
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, shape_info_buffer);
            GL.BufferData(BufferTarget.ShaderStorageBuffer, lined_shapes.Count * Unsafe.SizeOf<ShapeInfo>(), lined_shapes.ToArray(), BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, 0);
            GL.BindBufferBase(BufferRangeTarget.ShaderStorageBuffer, 2, shape_info_buffer);
        }

        private void render_filled() {
            bind_filled_info();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
        }
        private void render_lined() {
            bind_lined_info();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
        }
    }
}
