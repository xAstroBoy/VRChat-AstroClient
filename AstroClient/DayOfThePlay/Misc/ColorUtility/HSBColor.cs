using System;
using UnityEngine;

namespace DayClientML2.Utility.ColorUtility
{
    [Serializable]
    public struct HSBColor
    {
        public HSBColor(float float_0, float float_1, float float_2, float float_3)
        {
            this.h = float_0;
            this.s = float_1;
            this.b = float_2;
            this.a = float_3;
        }

        public HSBColor(float float_0, float float_1, float float_2)
        {
            this.h = float_0;
            this.s = float_1;
            this.b = float_2;
            this.a = 1f;
        }

        public HSBColor(Color color_0)
        {
            HSBColor hsbcolor = HSBColor.FromColor(color_0);
            this.h = hsbcolor.h;
            this.s = hsbcolor.s;
            this.b = hsbcolor.b;
            this.a = hsbcolor.a;
        }

        public static HSBColor FromColor(Color color)
        {
            HSBColor hsbcolor = new HSBColor(0f, 0f, 0f, color.a);
            float r = color.r;
            float g = color.g;
            float num = color.b;
            float num2 = Mathf.Max(r, Mathf.Max(g, num));
            if (num2 > 0f)
            {
                float num3 = Mathf.Min(r, Mathf.Min(g, num));
                float num4 = num2 - num3;
                if (num2 <= num3)
                {
                    hsbcolor.h = 0f;
                }
                else
                {
                    if (g != num2)
                    {
                        if (num == num2)
                        {
                            hsbcolor.h = (r - g) / num4 * 60f + 240f;
                        }
                        if (num <= g)
                        {
                            hsbcolor.h = (g - num) / num4 * 60f;
                        }
                        else
                        {
                            hsbcolor.h = (g - num) / num4 * 60f + 360f;
                        }
                    }
                    else
                    {
                        hsbcolor.h = (num - r) / num4 * 60f + 120f;
                    }
                    if (hsbcolor.h < 0f)
                    {
                        hsbcolor.h += 360f;
                    }
                }
                hsbcolor.h *= 0.0027777778f;
                hsbcolor.s = num4 / num2 * 1f;
                hsbcolor.b = num2;
                return hsbcolor;
            }
            return hsbcolor;
        }

        public static Color ToColor(HSBColor hsbColor)
        {
            float value = hsbColor.b;
            float value2 = hsbColor.b;
            float value3 = hsbColor.b;
            if (hsbColor.s != 0f)
            {
                float num = hsbColor.b;
                float num2 = hsbColor.b * hsbColor.s;
                float num3 = hsbColor.b - num2;
                float num4 = hsbColor.h * 360f;
                if (num4 < 60f)
                {
                    value = num;
                    value2 = num4 * num2 / 60f + num3;
                    value3 = num3;
                }
                if (num4 >= 120f)
                {
                    if (num4 >= 180f)
                    {
                        if (num4 >= 240f)
                        {
                            if (num4 >= 300f)
                            {
                                if (num4 > 360f)
                                {
                                    value = 0f;
                                    value2 = 0f;
                                    value3 = 0f;
                                }
                                else
                                {
                                    value = num;
                                    value2 = num3;
                                    value3 = -(num4 - 360f) * num2 / 60f + num3;
                                }
                            }
                            else
                            {
                                value = (num4 - 240f) * num2 / 60f + num3;
                                value2 = num3;
                                value3 = num;
                            }
                        }
                        else
                        {
                            value = num3;
                            value2 = -(num4 - 240f) * num2 / 60f + num3;
                            value3 = num;
                        }
                    }
                    else
                    {
                        value = num3;
                        value2 = num;
                        value3 = (num4 - 120f) * num2 / 60f + num3;
                    }
                }
                else
                {
                    value = -(num4 - 120f) * num2 / 60f + num3;
                    value2 = num;
                    value3 = num3;
                }
            }
            return new Color(Mathf.Clamp01(value), Mathf.Clamp01(value2), Mathf.Clamp01(value3), hsbColor.a);
        }

        public Color ToColor()
        {
            return HSBColor.ToColor(this);
        }

        public override string ToString()
        {
            return string.Concat(new string[]
            {
                "H:",
                this.h.ToString(),
                " S:",
                this.s.ToString(),
                " B:",
                this.b.ToString()
            });
        }

        public static HSBColor Lerp(HSBColor a, HSBColor b, float t)
        {
            float float_;
            float float_2;
            if (a.b == 0f)
            {
                float_ = b.h;
                float_2 = b.s;
            }
            if (b.b != 0f)
            {
                if (a.s != 0f)
                {
                    if (b.s != 0f)
                    {
                        float num;
                        for (num = Mathf.LerpAngle(a.h * 360f, b.h * 360f, t); num < 0f; num += 360f)
                        {
                        }
                        while (num > 360f)
                        {
                            num -= 360f;
                        }
                        float_ = num / 360f;
                    }
                    else
                    {
                        float_ = a.h;
                    }
                }
                else
                {
                    float_ = b.h;
                }
                float_2 = Mathf.Lerp(a.s, b.s, t);
            }
            else
            {
                float_ = a.h;
                float_2 = a.s;
            }
            return new HSBColor(float_, float_2, Mathf.Lerp(a.b, b.b, t), Mathf.Lerp(a.a, b.a, t));
        }

        public float h;

        public float s;

        public float b;

        public float a;
    }
}