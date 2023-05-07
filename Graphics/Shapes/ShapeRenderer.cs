using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using ArcadiaEngine.Common;

namespace ArcadiaEngine.Graphics.Shapes {
    internal class ShapeRenderer {
        const int CIRCLE_DEFINITION = 40;

        private struct SentShapeInfo {
            public Matrix4 model;
            public Vector4 color;

            public SentShapeInfo(ShapeInfo shape) {
                model = Matrix4.CreateScale(shape.scale, shape.scale, 1);
                color = shape.color;
            }
        };

        protected int vertex_array;
        protected int vertex_buffer;

        public int shape_info_buffer { get; set; }
        public List<ShapeInfo> shapes { get; }

        public ShapeRenderer() {
            vertex_array = GL.GenVertexArray();
            vertex_buffer = GL.GenBuffer();

            shape_info_buffer = GL.GenBuffer();
            shapes = new List<ShapeInfo>();
        }

        public void add_shape(params ShapeInfo[] shapes_to_add) {
            foreach(ShapeInfo shape in shapes_to_add)
                shapes.Add(shape);
        }

        private void bind_shape_info(SentShapeInfo shape) {
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, shape_info_buffer);
            unsafe {
                    GL.BufferData(BufferTarget.ShaderStorageBuffer, Unsafe.SizeOf<SentShapeInfo>(), (IntPtr)(&shape), BufferUsageHint.DynamicDraw);
            }
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, 0);
            GL.BindBufferBase(BufferRangeTarget.ShaderStorageBuffer, 2, shape_info_buffer);
        }

        protected void set_filled(bool filled) {
            if(filled)
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            else
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
        }

        protected void update_vertex_buffer(Vector2[] vertices) {
            GL.BindVertexArray(vertex_array);          
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertex_buffer);

            GL.BufferData(BufferTarget.ArrayBuffer, Unsafe.SizeOf<Vector2>() * vertices.Length, vertices, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void render() {
            foreach(ShapeInfo shape in shapes) {
                bind_shape_info(new SentShapeInfo(shape));
                update_vertex_buffer(shape.positions);

                GL.BindVertexArray(vertex_array);
                switch(shape.shape) {
                    case ShapeType.RectangleFill:
                        GL.DrawArrays(PrimitiveType.Quads, 0, 1);
                        break;
                    case ShapeType.RectangleLine:
                        set_filled(false);
                        GL.DrawArrays(PrimitiveType.Quads, 0, 1);
                        break;
                    case ShapeType.TriangleFill:
                        GL.DrawArrays(PrimitiveType.Triangles, 0, 1);
                        break;
                    case ShapeType.TriangleLine:
                        set_filled(false);
                        GL.DrawArrays(PrimitiveType.Triangles, 0, 1);
                        break;
                    case ShapeType.CircleFill:
                        GL.DrawArrays(PrimitiveType.Triangles, 0, CIRCLE_DEFINITION);
                        break;
                    case ShapeType.CircleLine:
                        GL.DrawArrays(PrimitiveType.LineLoop, 0, CIRCLE_DEFINITION + 1);
                        break;
                    default:
                        break;
                }
                GL.BindVertexArray(0);

                set_filled(true);
            }

            shapes.Clear();
        }
    }
}
