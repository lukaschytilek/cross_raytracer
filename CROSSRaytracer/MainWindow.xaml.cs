using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using CROSSRaytracer.Objects;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace CROSSRaytracer
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.loadingBar.Visibility = Visibility.Hidden;
        }

        private void RenderSphere(object sender, RoutedEventArgs e)
        {
            this.canvasView.Children.Clear();

            int width = (int)this.canvasView.Width;
            int height = (int)this.canvasView.Height;

            Vector3D sphereColor = new Vector3D(255, 255, 255);
            Vector3D lightColor = new Vector3D(255, 0, 0);
            Sphere sphere = new Sphere(100, new Vector3D(width / 2, height / 2, 50));
            Vector3D light = new Vector3D(0, 0, 50);

            this.loadingBar.Visibility = Visibility.Visible;
            Task.Run(() =>
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Vector3D pixelColor = new Vector3D();

                        RayTracer rayTracer = new RayTracer(new Vector3D(x, y, 0), new Vector3D(0, 0, 1));
                        double point = 0;
                        if (sphere.intersect(rayTracer, ref point))
                        {
                            Vector3D intersectPoint = rayTracer.origin + (rayTracer.direction * point);
                            Vector3D lightVector = light - intersectPoint;
                            Vector3D sphereNormal = sphere.calcNormal(intersectPoint);

                            lightVector.Normalize();
                            sphereNormal.Normalize();

                            double dotT = Vector3D.DotProduct(lightVector, sphereNormal);

                            pixelColor = (lightColor + (sphereColor * dotT)) * 0.5;

                            pixelColor.X = (pixelColor.X > 255) ? 255 : (pixelColor.X < 0) ? 0 : pixelColor.X;
                            pixelColor.Y = (pixelColor.Y > 255) ? 255 : (pixelColor.Y < 0) ? 0 : pixelColor.Y;
                            pixelColor.Z = (pixelColor.Z > 255) ? 255 : (pixelColor.Z < 0) ? 0 : pixelColor.Z;

                            this.Dispatcher.Invoke(() =>
                            {
                                Ellipse drawPoint = new Ellipse();
                                SolidColorBrush solidColorBrush = new SolidColorBrush();
                                solidColorBrush.Color = Color.FromRgb((byte)pixelColor.X, (byte)pixelColor.Y, (byte)pixelColor.Z);
                                drawPoint.Width = 1;
                                drawPoint.Height = 1;
                                drawPoint.Fill = solidColorBrush;
                                drawPoint.StrokeThickness = 1;

                                Canvas.SetLeft(drawPoint, x);
                                Canvas.SetTop(drawPoint, y);

                                this.canvasView.Children.Add(drawPoint);
                            });
                        }

                        if (x == width - 1 && y == height - 1)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                this.loadingBar.Visibility = Visibility.Hidden;
                            });
                        }
                    }
                }
            });
        }

        private void RenderTriangle(object sender, RoutedEventArgs e)
        {
            this.canvasView.Children.Clear();

            int width = (int)this.canvasView.Width;
            int height = (int)this.canvasView.Height;

            Vector3D sphereColor = new Vector3D(255, 255, 255);
            Vector3D lightColor = new Vector3D(255, 0, 0);
            Vector3D triangleCenter = new Vector3D(width / 2, height / 2, 50);
            Triangle triangle = new Triangle(
                new Vector3D(triangleCenter.X - 100, triangleCenter.Y + 75, triangleCenter.Z),
                new Vector3D(triangleCenter.X + 50, triangleCenter.Y, triangleCenter.Z),
                new Vector3D(triangleCenter.X - 100, triangleCenter.Y - 75, triangleCenter.Z));

            Vector3D light = new Vector3D(0, 0, 50);

            this.loadingBar.Visibility = Visibility.Visible;
            Task.Run(() =>
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Vector3D pixelColor = new Vector3D();
                        Vector3D[] cols = { new Vector3D(0.6, 0.4, 0.1), new Vector3D(0.1, 0.5, 0.3), new Vector3D(0.1, 0.3, 0.7) };

                        RayTracer rayTracer = new RayTracer(new Vector3D(x, y, 0), new Vector3D(0, 0, 1));
                        Vector3D point = new Vector3D(0, 0, 0);
                        if (triangle.intersect(rayTracer, ref point))
                        {
                            Vector3D intersectPoint = rayTracer.origin + (rayTracer.direction * point.X);
                            Vector3D lightVector = light - intersectPoint;
                            Vector3D triangleNormal = triangle.calcNormal(intersectPoint);

                            lightVector.Normalize();
                            triangleNormal.Normalize();

                            double dotT = Vector3D.DotProduct(lightVector, triangleNormal);

                            pixelColor = (lightColor + (sphereColor * dotT)) * 0.5;
                            pixelColor = new Vector3D(point.Y, point.Z, 1 - point.Y - point.Z);

                            pixelColor.X = (pixelColor.X > 255) ? 255 : (pixelColor.X < 0) ? 0 : pixelColor.X;
                            pixelColor.Y = (pixelColor.Y > 255) ? 255 : (pixelColor.Y < 0) ? 0 : pixelColor.Y;
                            pixelColor.Z = (pixelColor.Z > 255) ? 255 : (pixelColor.Z < 0) ? 0 : pixelColor.Z;

                            this.Dispatcher.Invoke(() =>
                            {
                                Ellipse drawPoint = new Ellipse();
                                SolidColorBrush solidColorBrush = new SolidColorBrush();
                                solidColorBrush.Color = Color.FromRgb((byte)pixelColor.X, (byte)pixelColor.Y, (byte)pixelColor.Z);
                                drawPoint.Width = 1;
                                drawPoint.Height = 1;
                                drawPoint.Fill = solidColorBrush;
                                drawPoint.StrokeThickness = 1;

                                Canvas.SetLeft(drawPoint, x);
                                Canvas.SetTop(drawPoint, y);

                                this.canvasView.Children.Add(drawPoint);
                            });
                        }

                        if (x == width - 1 && y == height - 1)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                this.loadingBar.Visibility = Visibility.Hidden;
                            });
                        }
                    }
                }
            });
        }

        private void RenderPlane(object sender, RoutedEventArgs e)
        {
            this.canvasView.Children.Clear();

            int width = (int)this.canvasView.Width;
            int height = (int)this.canvasView.Height;

            Vector3D sphereColor = new Vector3D(255, 255, 255);
            Vector3D lightColor = new Vector3D(255, 0, 0);
            Plane plane = new Plane(new Vector3D(1, 1, 1), new Vector3D(0, 0, -1));
            Vector3D light = new Vector3D(0, 0, 5);

            this.loadingBar.Visibility = Visibility.Visible;
            Task.Run(() =>
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Vector3D pixelColor = new Vector3D();

                        RayTracer rayTracer = new RayTracer(new Vector3D(x, y, 0), new Vector3D(0, 0, 1));
                        double point = 0;
                        if (plane.intersect(rayTracer, ref point))
                        {
                            Vector3D intersectPoint = rayTracer.origin + (rayTracer.direction * point);
                            Vector3D lightVector = light - intersectPoint;

                            lightVector.Normalize();
                            plane.normal.Normalize();

                            double dotT = Vector3D.DotProduct(lightVector, plane.normal);

                            pixelColor = (lightColor + (sphereColor * dotT)) * 0.5;

                            pixelColor.X = (pixelColor.X > 255) ? 255 : (pixelColor.X < 0) ? 0 : pixelColor.X;
                            pixelColor.Y = (pixelColor.Y > 255) ? 255 : (pixelColor.Y < 0) ? 0 : pixelColor.Y;
                            pixelColor.Z = (pixelColor.Z > 255) ? 255 : (pixelColor.Z < 0) ? 0 : pixelColor.Z;

                            this.Dispatcher.Invoke(() =>
                            {
                                Ellipse drawPoint = new Ellipse();
                                SolidColorBrush solidColorBrush = new SolidColorBrush();
                                solidColorBrush.Color = Color.FromRgb((byte)pixelColor.X, (byte)pixelColor.Y, (byte)pixelColor.Z);
                                drawPoint.Width = 1;
                                drawPoint.Height = 1;
                                drawPoint.Fill = solidColorBrush;
                                drawPoint.StrokeThickness = 1;

                                Canvas.SetLeft(drawPoint, x);
                                Canvas.SetTop(drawPoint, y);

                                this.canvasView.Children.Add(drawPoint);
                            });
                        }

                        if (x == width - 1 && y == height - 1)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                this.loadingBar.Visibility = Visibility.Hidden;
                            });
                        }
                    }
                }
            });
        }
    }
}